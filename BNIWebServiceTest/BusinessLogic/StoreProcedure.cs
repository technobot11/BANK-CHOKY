using BNIWebServiceTest.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BNIWebServiceTest.BusinessLogic
{
    public class StoreProcedure
    {
        private SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["BNITest"].ToString());
        }
        public void InsertDataNasabah(CreateModelDataNasabah data)
        {
            var conn = GetConnection();
            conn.Open();

            var storedProcedure = "[dbo].[InsertDataNasabah]";

            var cmd = new SqlCommand
            {
                CommandText = storedProcedure,
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 7200,
                Connection = conn
            };

            cmd.Parameters.AddWithValue("@Nama", data.NamaLengkap);
            cmd.Parameters.AddWithValue("@Alamat", data.Alamat);
            cmd.Parameters.AddWithValue("@Kota", data.Kota);
            cmd.Parameters.AddWithValue("@TempatLahir", data.TempatLahir);
            cmd.Parameters.AddWithValue("@TanggalLahir", Convert.ToDateTime(data.TanggalLahir));
            cmd.Parameters.AddWithValue("@NomorKTP", data.NomorKTP);
            cmd.Parameters.AddWithValue("@NomorHandphone", data.NomorHandphone);
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        //public DataNasabah GetDataNasabahByNoKTP(string nomorKTP)
        //{
        //    DataNasabah dataNasabah = new DataNasabah();

        //    var con = GetConnection();
        //    con.Open();

        //    var cmd = new SqlCommand("[dbo].[GetDataNasabahByNoKTP]", con);
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    cmd.CommandTimeout = 7200;
        //    var sd = new SqlDataAdapter(cmd);
        //    var dt = new DataTable();

        //    cmd.Parameters.AddWithValue("@NomorKTP", nomorKTP);

        //    sd.Fill(dt);
        //    con.Close();

        //    if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        //    {
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            dataNasabah.NamaLengkap = dr["NamaLengkap"].ToString();
        //            dataNasabah.Alamat = dr["Alamat"].ToString();
        //            dataNasabah.Kota = dr["Kota"].ToString();
        //            dataNasabah.TempatLahir = dr["TempatLahir"].ToString();
        //            dataNasabah.TanggalLahir = Convert.ToDateTime(dr["TanggalLahir"]);
        //            dataNasabah.NomorKTP = dr["NomorKTP"].ToString();
        //            dataNasabah.NomorHandphone = dr["NomorHandphone"].ToString();
        //        }
        //    }

        //    return dataNasabah;
        //}

        public List<DataNasabah> GetAllDataNasabah()
        {
            List<DataNasabah> listdataNasabah = new List<DataNasabah>();

            try
            {
                var con = GetConnection();
                con.Open();

                var cmd = new SqlCommand("[dbo].[GetAllDataNasabah]", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandTimeout = 7200;
                var sd = new SqlDataAdapter(cmd);
                var dt = new DataTable();

                sd.Fill(dt);
                con.Close();

                if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        DataNasabah dtNas = new DataNasabah();
                        dtNas.NamaLengkap = dr["NamaLengkap"].ToString();
                        dtNas.Alamat = dr["Alamat"].ToString();
                        dtNas.Kota = dr["Kota"].ToString();
                        dtNas.TempatLahir = dr["TempatLahir"].ToString();
                        dtNas.TanggalLahir = Convert.ToDateTime(dr["TanggalLahir"]);
                        dtNas.NomorKTP = dr["NomorKTP"].ToString();
                        dtNas.NomorHandphone = dr["NomorHandphone"].ToString();

                        listdataNasabah.Add(dtNas);
                    }
                }

            }
            catch (Exception err)
            {
                throw err;
            }

            return listdataNasabah;
        }

        public void UpdateDataNasabah(UpdateModelDataNasabah model)
        {
            var con = GetConnection();
            con.Open();

            var cmd = new SqlCommand("[dbo].[UpdateDataNasabah]", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandTimeout = 7200;
            var sd = new SqlDataAdapter(cmd);
            var dt = new DataTable();

            cmd.Parameters.AddWithValue("@NomorKTP", model.NomorKTP);
            cmd.Parameters.AddWithValue("@Alamat", model.Alamat);
            cmd.Parameters.AddWithValue("@Kota", model.Kota);
            cmd.Parameters.AddWithValue("@NomorHandphone", model.NomorHandphone);
            cmd.ExecuteNonQuery();

        }

        public string DeleteDataNasabah(DeleteModelDataNasabah model)
        {
            var message = string.Empty;

            try
            {
                var con = GetConnection();
                con.Open();

                var cmd = new SqlCommand("[dbo].[DeleteDataNasabah]", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandTimeout = 7200;
                var sd = new SqlDataAdapter(cmd);
                var dt = new DataTable();

                cmd.Parameters.AddWithValue("@NomorKTP", model.NomorKTP);
                cmd.ExecuteNonQuery();

                message = "Success";

            }
            catch (Exception err)
            {
                message = err.Message;
            }

            return message;
        }

    }
}