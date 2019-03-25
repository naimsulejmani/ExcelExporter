using System;
using System.Data;
using System.Drawing;
using System.IO;

namespace ExcelExporter.DataAccess
{
    public class DataAccessObject
    {
        #region Methods

        public static void AddParameter(IDbCommand command, String parameterName, Object value)
        {
            IDataParameter parameter = command.CreateParameter();
            parameter.ParameterName = parameterName;
            if (value != null)
            {
                if (value is DateTime)
                {
                    if (DateTime.Parse(value.ToString()) <= DateTime.Parse("1/01/1900 12:00:00"))
                        value = null;
                }
                else if (value is Bitmap)
                    value = ImageToByteArray((Image)(value));

            }
            parameter.Value = value ?? DBNull.Value;
            command.Parameters.Add(parameter);
        }

        public static void AddParameter(IDbCommand command, String parameterName, Object value, DbType databaseType)
        {
            IDataParameter parameter = command.CreateParameter();
            parameter.ParameterName = parameterName;
            if (value != null)
            {
                if (value is DateTime)
                {
                    if (DateTime.Parse(value.ToString()) <= DateTime.Parse("1/01/1990 12:00:00"))
                        value = null;
                }
                else if (value is Bitmap)
                    value = ImageToByteArray((Image)(value));

            }
            parameter.Value = value ?? DBNull.Value;
            parameter.DbType = databaseType;
            command.Parameters.Add(parameter);
        }

        public static void AddParameter(IDbCommand command, String parameterName, Object value, DbType databaseType,
            ParameterDirection parameterDirection)
        {
            IDataParameter parameter = command.CreateParameter();
            parameter.ParameterName = parameterName;
            parameter.Value = value ?? DBNull.Value;
            parameter.DbType = databaseType;
            parameter.Direction = parameterDirection;
            command.Parameters.Add(parameter);
        }

        public static Byte[] ImageToByteArray(Image imageIn)
        {
            if (imageIn != null)
            {
                var ms = new MemoryStream();
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return ms.ToArray();
            }
            return null;
        }

        public static Image ByteArrayToImage(Byte[] byteArrayIn)
        {
            if (byteArrayIn != null)
            {
                var ms = new MemoryStream(byteArrayIn);
                var returnImage = Image.FromStream(ms);
                return returnImage;
            }
            return null;
        }

        #endregion
    }
}
