﻿using Models;
using Microsoft.Data.SqlClient;

namespace DataAccess;
public class ConnectionFactory{
    private static ConnectionFactory? _instance;
    private readonly string _connectionString;
    
    private ConnectionFactory(string connectionString) 
    {
        _connectionString = connectionString;
    }

    public static ConnectionFactory GetInstance(string connectionString)
    {
        Console.WriteLine($"string {connectionString}");
        if(_instance == null)
        {
            _instance = new ConnectionFactory(connectionString);
        }
        return _instance;
    }

    public SqlConnection GetConnection()
    {
        return new SqlConnection(_connectionString);
    }
}

