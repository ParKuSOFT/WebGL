using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;

namespace WebGL.Models
{
    public class Model3DRepository
    {
        private OdbcConnection db;

        public Model3DRepository(string connectionString)
        {
            db = new OdbcConnection();
            db.ConnectionString = connectionString; // или прямо тут строку
            db.Open();
        }

        public List<float> GetVertices(int modelId)
        {
            OdbcDataAdapter ad = new OdbcDataAdapter();
            ad.SelectCommand = new OdbcCommand();
            ad.SelectCommand.Connection = db;
            ad.SelectCommand.CommandText = "SELECT * FROM Vertices_Sphere WHERE ModelId = ? ORDER BY VertexOrder";

            OdbcParameter modelIdParam = new OdbcParameter("@modelId", modelId);
            ad.SelectCommand.Parameters.Add(modelIdParam);
            ad.SelectCommand.ExecuteNonQuery();

            DataSet ds = new DataSet();
            ad.Fill(ds);

            List<float> vertices = new List<float>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                vertices.Add(Convert.ToSingle(ds.Tables[0].Rows[i]["X"]));
                vertices.Add(Convert.ToSingle(ds.Tables[0].Rows[i]["Y"]));
                vertices.Add(Convert.ToSingle(ds.Tables[0].Rows[i]["Z"]));
            }

            return vertices;
        }

        public List<float> GetNormalsGradient(int modelId)
        {
            OdbcDataAdapter ad = new OdbcDataAdapter();
            ad.SelectCommand = new OdbcCommand();
            ad.SelectCommand.Connection = db;
            ad.SelectCommand.CommandText = "SELECT * FROM Normals_Sphere WHERE ModelId = ? ORDER BY VertexOrder";

            OdbcParameter modelIdParam = new OdbcParameter("@modelId", modelId);
            ad.SelectCommand.Parameters.Add(modelIdParam);
            ad.SelectCommand.ExecuteNonQuery();

            DataSet ds = new DataSet();
            ad.Fill(ds);

            List<float> normals = new List<float>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                normals.Add(Convert.ToSingle(ds.Tables[0].Rows[i]["NX"]));
                normals.Add(Convert.ToSingle(ds.Tables[0].Rows[i]["NY"]));
                normals.Add(Convert.ToSingle(ds.Tables[0].Rows[i]["NZ"]));
            }

            return normals;
        }

        public List<float> GetColors(int modelId)
        {
            OdbcDataAdapter ad = new OdbcDataAdapter();
            ad.SelectCommand = new OdbcCommand();
            ad.SelectCommand.Connection = db;
            ad.SelectCommand.CommandText = "SELECT * FROM Colors_Sphere WHERE ModelId = ? ORDER BY VertexOrder";

            OdbcParameter modelIdParam = new OdbcParameter("@modelId", modelId);
            ad.SelectCommand.Parameters.Add(modelIdParam);
            ad.SelectCommand.ExecuteNonQuery();

            DataSet ds = new DataSet();
            ad.Fill(ds);

            List<float> colors = new List<float>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                colors.Add(Convert.ToSingle(ds.Tables[0].Rows[i]["R"]));
                colors.Add(Convert.ToSingle(ds.Tables[0].Rows[i]["G"]));
                colors.Add(Convert.ToSingle(ds.Tables[0].Rows[i]["B"]));
            }

            return colors;
        }

        public List<int> GetIndices(int modelId)
        {
            OdbcDataAdapter ad = new OdbcDataAdapter();
            ad.SelectCommand = new OdbcCommand();
            ad.SelectCommand.Connection = db;
            ad.SelectCommand.CommandText = "SELECT * FROM Indices_Sphere WHERE ModelId = ? ORDER BY IndexOrder";

            OdbcParameter modelIdParam = new OdbcParameter("@modelId", modelId);
            ad.SelectCommand.Parameters.Add(modelIdParam);
            ad.SelectCommand.ExecuteNonQuery();

            DataSet ds = new DataSet();
            ad.Fill(ds);

            List<int> indices = new List<int>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                indices.Add(Convert.ToInt32(ds.Tables[0].Rows[i]["IndexValue"]));
            }

            return indices;
        }

        public void Close()
        {
            if (db != null && db.State == ConnectionState.Open)
            {
                db.Close();
            }
        }
    }
}

