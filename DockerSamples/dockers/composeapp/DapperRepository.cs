﻿using System;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;

namespace composeapp
{
    public class DapperRepository
    {
        private string _connectionString;
        public DapperRepository()
        {
            _connectionString = "host=db;port=3306;database=test;userid=sa;password=123123";
        }

        public IDbConnection Connection()
        {
            return new MySqlConnection(_connectionString);
        }

        #region Execute

        public virtual bool Execute(string sql, object param = null)
        {
            using (var conn = Connection())
            {
                return conn.Execute(sql, param) > 0;
            }
        }
        public virtual async Task<bool> ExecuteAsync(string sql, object param = null)
        {
            using (var conn = Connection())
            {
                return await conn.ExecuteAsync(sql, param) > 0;
            }
        }

        #endregion

        #region ExecuteScalar

        public virtual T ExecuteScalar<T>(string sql, object param = null)
        {
            using (var conn = Connection())
            {
                return conn.ExecuteScalar<T>(sql, param);
            }
        }
        public virtual async Task<T> ExecuteScalarAsync<T>(string sql, object param = null)
        {
            using (var conn = Connection())
            {
                return await conn.ExecuteScalarAsync<T>(sql, param);
            }
        }

        #endregion

        #region Query

        public virtual IEnumerable<T> Query<T>(string sql, object param = null)
        {
            using (var conn = Connection())
            {
                return conn.Query<T>(sql, param);
            }
        }
        public virtual async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null)
        {
            using (var conn = Connection())
            {
                return await conn.QueryAsync<T>(sql, param);
            }
        }

        #endregion

        #region QueryFirst

        public virtual T QueryFirst<T>(string sql, object param = null)
        {
            using (var conn = Connection())
            {
                return conn.QueryFirstOrDefault<T>(sql, param);
            }
        }
        public virtual async Task<T> QueryFirstAsync<T>(string sql, object param = null)
        {
            using (var conn = Connection())
            {
                return await conn.QueryFirstOrDefaultAsync<T>(sql, param);
            }
        }

        #endregion
    }
}
