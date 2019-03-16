using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Services.BusinessLogic
{
    public class ExcelReader
    {
        public static String filePath = @"F:\2018\HBIO\HBIO-DataServices\Player_Data.xlsx";

        public static DataTable ImportExcel()
        {
            DataTable table = new DataTable();
            FileInfo file = new FileInfo(filePath);
            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                int rowCount = worksheet.Dimension.Rows;
                int colCount = worksheet.Dimension.Columns;
                
                var rawText = string.Empty;

                for (int row = 0; row < rowCount; row++)
                {
                    int i = 0;
                    DataRow newRow = table.NewRow();
                    
                    for (int col = 0; col < colCount; col++)
                    {
                        if (row == 0)
                        {
                            DataColumn column = new DataColumn();
                            column.DataType = typeof(String);
                            column.ColumnName = Convert.ToString(((object[,])worksheet.Cells.Value)[row, col]);
                            table.Columns.Add(column);
                        }
                        else
                        {
                            newRow[col] = Convert.ToString(((object[,])worksheet.Cells.Value)[row, col]);
                        }
                    }

                    table.Rows.Add(newRow);
                }

                return table;
            }
        }
    }
}
