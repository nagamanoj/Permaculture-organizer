using PermacultureOrganizer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace PermacultureOrganizer.DAL
{
    public class AnimalDAL
    {
        private string ConnectionString = WebConfigurationManager.ConnectionStrings["PermaCultureConnection"].ConnectionString;

        /// <summary>
        /// Retrieves a single livestock object by the ID passed
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public DataTable GetLiveStockByID(int ID)
        {
            DataTable dtLiveStock = new DataTable("dtLiveStock");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "usp_LiveStockSelect";
                    command.Parameters.Add("@LiveStockID", SqlDbType.Int).Value = ID;

                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        DataSet ds = new DataSet();
                        connection.Open();
                        
                        try
                        {
                            da.Fill(ds);

                            dtLiveStock = ds.Tables[0];
                        }
                        catch (SqlException ReadError)
                        {
                            DataRow ErrorRow = dtLiveStock.NewRow();
                            dtLiveStock.Columns.Add("ErrorMessage");
                            ErrorRow["ErrorMessage"] = ReadError.Message.ToString();
                            dtLiveStock.Columns.Add("ErrorLineNumber");
                            ErrorRow["ErrorLineNumber"] = ReadError.Message.ToString();
                            dtLiveStock.Rows.Add(ErrorRow);
                        }
                    }
                }
                catch (Exception ex)
                {

                }

                return dtLiveStock;
            }
        }

        /// <summary>
        /// Retrieves all Livestock descriptions
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllLiveStockDescription()
        {
            DataTable dtLiveStock = new DataTable("dtLiveStock");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "GetAllLiveStockDescription";

                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        DataSet ds = new DataSet();
                        connection.Open();
                        try
                        {
                            da.Fill(ds);

                            dtLiveStock = ds.Tables[0];
                        }
                        catch (SqlException ReadError)
                        {
                            DataRow ErrorRow = dtLiveStock.NewRow();
                            dtLiveStock.Columns.Add("ErrorMessage");
                            ErrorRow["ErrorMessage"] = ReadError.Message.ToString();
                            dtLiveStock.Columns.Add("ErrorLineNumber");
                            ErrorRow["ErrorLineNumber"] = ReadError.Message.ToString();
                            dtLiveStock.Rows.Add(ErrorRow);
                        }
                    }
                }
                catch (Exception ex)
                {

                }

                return dtLiveStock;
            }
        }

        /// <summary>
        /// Retrieves breed information based on a livestockid
        /// </summary>
        /// <param name="LiveStockID"></param>
        /// <returns></returns>
        public DataTable GetBreedsForLiveStockID(int LiveStockID)
        {
            DataTable dtBreeds = new DataTable("dtBreeds");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "GetBreedInfoForLiveStock";
                    command.Parameters.Add("@LiveStockID", SqlDbType.Int).Value = LiveStockID;

                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        DataSet ds = new DataSet();
                        connection.Open();
                        try
                        {
                            da.Fill(ds);

                            dtBreeds = ds.Tables[0];
                        }
                        catch (SqlException ReadError)
                        {
                            DataRow ErrorRow = dtBreeds.NewRow();
                            dtBreeds.Columns.Add("ErrorMessage");
                            ErrorRow["ErrorMessage"] = ReadError.Message.ToString();
                            dtBreeds.Columns.Add("ErrorLineNumber");
                            ErrorRow["ErrorLineNumber"] = ReadError.Message.ToString();
                            dtBreeds.Rows.Add(ErrorRow);
                        }
                    }
                }
                catch (Exception ex)
                {

                }

                return dtBreeds;
            }
        }

        public DataTable GetBreedInfoByID(int BreedID)
        {
            DataTable dtBreed = new DataTable("dtBreed");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "usp_BreedsSelect";
                    command.Parameters.Add("@BreedID", SqlDbType.Int).Value = BreedID;

                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        DataSet ds = new DataSet();
                        connection.Open();

                        try
                        {
                            da.Fill(ds);

                            dtBreed = ds.Tables[0];
                        }
                        catch (SqlException ReadError)
                        {
                            DataRow ErrorRow = dtBreed.NewRow();
                            dtBreed.Columns.Add("ErrorMessage");
                            ErrorRow["ErrorMessage"] = ReadError.Message.ToString();
                            dtBreed.Columns.Add("ErrorLineNumber");
                            ErrorRow["ErrorLineNumber"] = ReadError.Message.ToString();
                            dtBreed.Rows.Add(ErrorRow);
                        }
                    }
                }
                catch (Exception ex)
                {

                }

                return dtBreed;
            }
        }

        /// <summary>
        /// Gets individual animals based on breedid
        /// </summary>
        /// <param name="BreedID"></param>
        /// <returns></returns>
        public DataTable GetIndividualAnimalsForBreedID(int BreedID)
        {
            DataTable dtIndividualAnimals = new DataTable("dtIndividualAnimals");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "GetIndividualAnimalForBreedID";
                    command.Parameters.Add("@BreedID", SqlDbType.Int).Value = BreedID;

                     using (SqlDataAdapter da = new SqlDataAdapter(command))
                     {
                         DataSet ds = new DataSet();
                         connection.Open();
                         try
                         {
                             da.Fill(ds);

                             dtIndividualAnimals = ds.Tables[0];
                         }
                         catch (SqlException ReadError)
                         {
                             DataRow ErrorRow = dtIndividualAnimals.NewRow();
                             dtIndividualAnimals.Columns.Add("ErrorMessage");
                             ErrorRow["ErrorMessage"] = ReadError.Message.ToString();
                             dtIndividualAnimals.Columns.Add("ErrorLineNumber");
                             ErrorRow["ErrorLineNumber"] = ReadError.Message.ToString();
                             dtIndividualAnimals.Rows.Add(ErrorRow);
                         }
                     }
                }
                catch(Exception ex)
                {

                }

                return dtIndividualAnimals;
            }
        }

        /// <summary>
        /// Gets an individual animal 
        /// </summary>
        /// <param name="IndividualAnimalID"></param>
        /// <returns></returns>
        public DataTable GetIndividualAnimal(int IndividualAnimalID)
        {
            DataTable dtIndividualAnimal = new DataTable("dtIndividualAnimal");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "usp_IndividualAnimalSelect";
                    command.Parameters.Add("@IndividualAnimalID", SqlDbType.Int).Value = IndividualAnimalID;

                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        DataSet ds = new DataSet();
                        connection.Open();
                        try
                        {
                            da.Fill(ds);

                            dtIndividualAnimal = ds.Tables[0];
                        }
                        catch (SqlException ReadError)
                        {
                            DataRow ErrorRow = dtIndividualAnimal.NewRow();
                            dtIndividualAnimal.Columns.Add("ErrorMessage");
                            ErrorRow["ErrorMessage"] = ReadError.Message.ToString();
                            dtIndividualAnimal.Columns.Add("ErrorLineNumber");
                            ErrorRow["ErrorLineNumber"] = ReadError.Message.ToString();
                            dtIndividualAnimal.Rows.Add(ErrorRow);
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }

            return dtIndividualAnimal;
        }

        /// <summary>
        /// Gets additional data for an object
        /// </summary>
        /// <param name="ObjectID"></param>
        /// <param name="ObjectName"></param>
        /// <returns></returns>
        public DataTable GetAdditionalData(int ObjectID, string ObjectName)
        {
            DataTable dtAdditionalData = new DataTable("dtAdditionalData");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "GetAllAdditionalDataForObject";
                    command.Parameters.Add("@ObjectName", SqlDbType.VarChar).Value = ObjectName;
                    command.Parameters.Add("@ObjectID", SqlDbType.Int).Value = ObjectID;

                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        DataSet ds = new DataSet();
                        connection.Open();
                        try
                        {
                            da.Fill(ds);

                            dtAdditionalData = ds.Tables[0];
                        }
                        catch (SqlException ReadError)
                        {
                            DataRow ErrorRow = dtAdditionalData.NewRow();
                            dtAdditionalData.Columns.Add("ErrorMessage");
                            ErrorRow["ErrorMessage"] = ReadError.Message.ToString();
                            dtAdditionalData.Columns.Add("ErrorLineNumber");
                            ErrorRow["ErrorLineNumber"] = ReadError.Message.ToString();
                            dtAdditionalData.Rows.Add(ErrorRow);
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }

            return dtAdditionalData;
        }

        /// <summary>
        /// Gets additional data for an object filtered by category
        /// </summary>
        /// <param name="ObjectID"></param>
        /// <param name="ObjectName"></param>
        /// <param name="Category"></param>
        /// <returns></returns>
        public DataTable GetSpecificAdditionalData(int ObjectID, string ObjectName, string Category)
        {
            DataTable dtAdditionalData = new DataTable("dtAdditionalData");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "GetSpecificAdditionalDataForObject";
                    command.Parameters.Add("@ObjectName", SqlDbType.VarChar).Value = ObjectName;
                    command.Parameters.Add("@ObjectID", SqlDbType.Int).Value = ObjectID;
                    command.Parameters.Add("DataCategory", SqlDbType.VarChar).Value = Category;

                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        DataSet ds = new DataSet();
                        connection.Open();
                        try
                        {
                            da.Fill(ds);

                            dtAdditionalData = ds.Tables[0];
                        }
                        catch (SqlException ReadError)
                        {
                            DataRow ErrorRow = dtAdditionalData.NewRow();
                            dtAdditionalData.Columns.Add("ErrorMessage");
                            ErrorRow["ErrorMessage"] = ReadError.Message.ToString();
                            dtAdditionalData.Columns.Add("ErrorLineNumber");
                            ErrorRow["ErrorLineNumber"] = ReadError.Message.ToString();
                            dtAdditionalData.Rows.Add(ErrorRow);
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }

            return dtAdditionalData;
        }

        public void UpdateLiveStock(LiveStockModel LiveStock)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "usp_LiveStockUpdate";
                    command.Parameters.Add("@LiveStockID", SqlDbType.Int).Value = LiveStock.LiveStockID;
                    command.Parameters.Add("@Description", SqlDbType.VarChar).Value = LiveStock.Description;
                    command.Parameters.Add("@Count", SqlDbType.Int).Value = LiveStock.Count;
                    command.Parameters.Add("@DietType", SqlDbType.VarChar).Value = LiveStock.DietType;
                    command.Parameters.Add("@FoodPerAnimal", SqlDbType.Int).Value = LiveStock.FoodPerAnimal;

                    connection.Open();

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
            }
        }

        public void UpdateBreed(BreedModel Breed)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "usp_BreedsUpdate";
                    command.Parameters.Add("@BreedID", SqlDbType.Int).Value = Breed.BreedID;
                    command.Parameters.Add("@LiveStockID", SqlDbType.Int).Value = Breed.LiveStockID;
                    command.Parameters.Add("@Name", SqlDbType.VarChar).Value = Breed.Name;
                    command.Parameters.Add("@Count", SqlDbType.Int).Value = Breed.Count;

                    connection.Open();

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
            }
        }

        public void UpdateIndividualAnmial(IndividualAnimalModel IndividualAnimal)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "usp_IndividualAnimalUpdate";
                    command.Parameters.Add("@IndividualAnimalID", SqlDbType.Int).Value = IndividualAnimal.IndividualAnimalID;
                    command.Parameters.Add("@Name", SqlDbType.VarChar).Value = IndividualAnimal.Name;
                    command.Parameters.Add("@Gender", SqlDbType.Char).Value = IndividualAnimal.Gender;
                    command.Parameters.Add("@BirthDate", SqlDbType.DateTime).Value = IndividualAnimal.BirthDate;
                    command.Parameters.Add("@FatherName", SqlDbType.VarChar).Value = IndividualAnimal.FatherName;
                    command.Parameters.Add("@FatherID", SqlDbType.Int).Value = IndividualAnimal.FatherID;
                    command.Parameters.Add("@MotherName", SqlDbType.VarChar).Value = IndividualAnimal.MotherName;
                    command.Parameters.Add("@MotherID", SqlDbType.Int).Value = IndividualAnimal.MotherID;
                    command.Parameters.Add("@BirthPlace", SqlDbType.VarChar).Value = IndividualAnimal.BirthPlace;
                    command.Parameters.Add("@DeathDate", SqlDbType.DateTime).Value = IndividualAnimal.DeathDate;
                    command.Parameters.Add("@Description", SqlDbType.VarChar).Value = IndividualAnimal.Description;
                    command.Parameters.Add("@PhotographID", SqlDbType.Int).Value = IndividualAnimal.PhotographID;

                    connection.Open();

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
            }
        }

        public void DeleteBreedInfo(int ID)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "usp_BreedsDelete";
                    command.Parameters.Add("@BreedID", SqlDbType.Int).Value = ID;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {

                }
            }
        }

        public void DeleteAnimalInfo(int ID)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "usp_IndividualAnimalDelete";
                    command.Parameters.Add("@IndividualAnimalID", SqlDbType.Int).Value = ID;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {

                }
            }
        }
        public void DeleteLiveStockInfo(int ID)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "usp_LiveStockDelete";
                    command.Parameters.Add("@LiveStockID", SqlDbType.Int).Value = ID;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {

                }
            }
        }

    }
}