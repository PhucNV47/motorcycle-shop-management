using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text.Json;

namespace MotorcycleShop.DAL
{
    public static class Database
    {
        private static string connectionString =
            @"Server=.;Database=MotorcycleShop;Trusted_Connection=True;TrustServerCertificate=True";
        public static DataTable ExecuteQuery(string sql, SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);

                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            return dt;
        }

        // INSERT / UPDATE / DELETE
        public static int ExecuteNonQuery(string sql, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);

                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                return cmd.ExecuteNonQuery();
            }
        }
        // Public logging helpers (lightweight structured logging)
        public static void LogInformation(string message, params (string Key, object Value)[] props)
            => Log("INFO", message, props);
        public static void LogWarning(string message, params (string Key, object Value)[] props)
            => Log("WARN", message, props);
        public static void LogError(string message, params (string Key, object Value)[] props)
            => Log("ERROR", message, props);

        static void Log(string level, string message, params (string Key, object Value)[] props)
        {
            try
            {
                var payload = new System.Text.Json.Nodes.JsonObject
                {
                    ["ts"] = DateTime.UtcNow.ToString("o"),
                    ["lvl"] = level,
                    ["msg"] = message
                };
                foreach (var p in props)
                    payload[p.Key] = p.Value?.ToString();

                var json = payload.ToJsonString();
                Console.Error.WriteLine(json);
                Debug.WriteLine(json);
            }
            catch
            {
                // Logging must not throw
            }
        }

        public static SqlConnection GetConnection()
        {
            // 1) Environment variable override
            var csFromEnv = Environment.GetEnvironmentVariable("MOTORCYCLESHOP_CONNECTION");
            if (!string.IsNullOrWhiteSpace(csFromEnv))
            {
                LogInformation("Using connection string from environment variable", ("source", "env"));
                return new SqlConnection(csFromEnv);
            }

            // 2) appsettings.json ConnectionStrings:MotorcycleShopDB
            try
            {
                var basePath = AppContext.BaseDirectory ?? Directory.GetCurrentDirectory();
                var appsettingsPath = Path.Combine(basePath, "appsettings.json");
                if (File.Exists(appsettingsPath))
                {
                    var json = File.ReadAllText(appsettingsPath);
                    using var doc = JsonDocument.Parse(json);
                    if (doc.RootElement.TryGetProperty("ConnectionStrings", out var csElem) &&
                        csElem.TryGetProperty("MotorcycleShopDB", out var namedCs))
                    {
                        var cs = namedCs.GetString();
                        if (!string.IsNullOrWhiteSpace(cs))
                        {
                            LogInformation("Using connection string from appsettings.json", ("source", "appsettings.json"));
                            return new SqlConnection(cs);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogWarning("Failed to read appsettings.json for connection string", ("err", ex.Message));
            }

            // 3) Try common instance names by attempting short connections
            var candidates = new[] { "(localdb)\\MSSQLLocalDB", ".\\SQLEXPRESS", "." };
            foreach (var candidate in candidates)
            {
                var testCs = $"Server={candidate};Database=MotorcycleShopDB;Trusted_Connection=True;TrustServerCertificate=True;Connect Timeout=3";
                try
                {
                    using var testConn = new SqlConnection(testCs);
                    testConn.Open();
                    testConn.Close();

                    // Found a responsive server
                    var finalCs = $"Server={candidate};Database=MotorcycleShopDB;Trusted_Connection=True;TrustServerCertificate=True";
                    LogInformation("Detected responsive SQL Server instance", ("server", candidate));
                    return new SqlConnection(finalCs);
                }
                catch (Exception ex)
                {
                    LogWarning("Candidate server not available", ("server", candidate), ("err", ex.Message));
                }
            }

            // 4) Fallback to default (same as before)
            var fallback = "Server=.;Database=MotorcycleShopDB;Trusted_Connection=True;TrustServerCertificate=True";
            LogWarning("Falling back to default connection string", ("connection", fallback));
            return new SqlConnection(fallback);
        }
    }
}
