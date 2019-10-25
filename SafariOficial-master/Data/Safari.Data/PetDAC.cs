using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Safari.Entities;

namespace Safari.Data
{
    public partial class PetDAC : DataAccessComponent, IRepository<Pet>
    {
        public Pet Create(Pet pet)
        {
            const string SQL_STATEMENT = "INSERT INTO Pet ([Name], [Gender], [OwnerName]) VALUES(@Name, @Gender, @OwnerName); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Name", DbType.AnsiString, pet.Name);
                db.AddInParameter(cmd, "@Gender", DbType.AnsiString, pet.Gender);
                db.AddInParameter(cmd, "@OwnerName", DbType.AnsiString, pet.OwnerName);
                pet.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return pet;
        }

        public List<Pet> Read()
        {
            const string SQL_STATEMENT = "SELECT [Id], [Name], [Gender], [OwnerName] FROM Pet ";

            List<Pet> result = new List<Pet>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Pet pet = LoadPet(dr);
                        result.Add(pet);
                    }
                }
            }
            return result;
        }

        public Pet ReadBy(int id)
        {
            const string SQL_STATEMENT = "SELECT [Id], [Name], [Gender], [OwnerName] FROM Pet WHERE [Id]=@Id ";
            Pet pet = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        pet = LoadPet(dr);
                    }
                }
            }
            return pet;
        }

        public void Update(Pet pet)
        {
            const string SQL_STATEMENT = "UPDATE Pet SET [Name]= @Name, [Gender] = @Gender, [OwnerName] = OwnerName WHERE [Id]= @Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Name", DbType.AnsiString, pet.Name);
                db.AddInParameter(cmd, "@Id", DbType.Int32, pet.Id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "DELETE Pet WHERE [Id]= @Id ";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public List<Pet> SelectPage(int currentPage)
        {
            const string SQL_STATEMENT =
                "WITH SortedPet AS " +
                "(SELECT ROW_NUMBER() OVER (ORDER BY [Id]) AS RowNumber, " +
                    "[Id] " +
                    "FROM dbo.Pet " +
                ") SELECT * FROM SortedPet " +
                "WHERE RowNumber BETWEEN @StartIndex AND @EndIndex";

            long startIndex = (currentPage * base.PageSize);
            long endIndex = startIndex + base.PageSize;

            startIndex += 1;
            List<Pet> result = new List<Pet>();

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@StartIndex", DbType.Int64, startIndex);
                db.AddInParameter(cmd, "@EndIndex", DbType.Int64, endIndex);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Pet especie = new Pet();
                        especie.Id = GetDataValue<int>(dr, "Id");
                        result.Add(especie);
                    }
                }
            }

            return result;
        }

        private Pet LoadPet(IDataReader dr)
        {
            Pet pet = new Pet();
            pet.Id = GetDataValue<int>(dr, "Id");
            pet.Name = GetDataValue<string>(dr, "Name");
            pet.Gender = GetDataValue<int>(dr, "Gender");
            pet.OwnerName = GetDataValue<string>(dr, "OwnerName");
            return pet;
        }
    }
}
