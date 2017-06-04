using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace Laga.IO
{
    public class IOExcelWrite
    {
        private string filePath;
        private int sheetNum;
        private string xlsxRange;

        private Excel.Application excelApp;
        private Excel.Workbook xlBook;
        private Excel.Worksheet xlSheet;
        private Excel.Range xlRange;

        private List<List<string>> dataExcel = new List<List<string>>();
        private List<string> lstDataExcel = new List<string>();
        private object misValue = System.Reflection.Missing.Value;

        #region public properties
        public int SheetNum
        {
            get
            {
                return sheetNum;
            }
        }
        /// <summary>
        /// set the data by nested string list format, use this to get the data from excel
        /// </summary>
        public List<List<string>> matrixDataExcel
        {
            set
            {
                dataExcel = value;
            }
        }

        /// <summary>
        /// set the data by string list format, use this to get the data from excel
        /// </summary>
        public List<string> listDataExcel
        {
            set
            {
                lstDataExcel = value;
            }
        }

        public static bool CheckExcelFile(string path)
        {
            return File.Exists(path);
        }

        #endregion

        #region constructors

        /// <summary>
        /// Sets the basic data to write in excel.
        /// do not forget call the open and close.
        /// </summary>
        /// <param name="FilePath">the direction to the file</param>
        /// <param name="SheetNumber">the number of the sheet to open</param>
        public IOExcelWrite(string FilePath, int SheetNumber)
        {
            this.filePath = FilePath;
            this.sheetNum = SheetNumber;
        }

        /// <summary>
        /// Creates and excel workbook.
        /// do not forget call the open and close.
        /// </summary>
        /// <param name="display">true, will display the workboook</param>
        public IOExcelWrite(bool display)
        {
            IOWrite_CreatesExcelApp(display);
        }

        /// <summary>
        /// Sets the basic data to write in excel.
        /// do not forget call the open and close.
        /// </summary>
        /// <param name="FilePath">the direction to the file</param>
        public IOExcelWrite(string FilePath)
        {
            this.filePath = FilePath;
        }
        #endregion

        /// <summary>
        /// open excel based on the constructor.
        /// </summary>
        /// <param name="display">if is true, show the excel"</param>
        public void IOWrite_NewExcelSheet(int pos, string name)
        {
            //var xlSheets = xlWorkBook.Sheets as Excel.Sheets;
            //var xlNewSheet = (Excel.Worksheet)xlSheets.Add(xlSheets[1], Type.Missing, Type.Missing, Type.Missing);
            //xlNewSheet.Name = "newsheet";

            xlSheet = (Excel.Worksheet)xlBook.Sheets.Add(Type.Missing, xlBook.Sheets[pos], 1, Excel.XlSheetType.xlWorksheet);
            xlSheet.Name = name;
        }

        /// <summary>
        /// Write in a specific worksheet.
        /// </summary>
        /// <param name="pos">the position of the excel sheet in the document.</param>
        public void IOWrite_SetActiveSheet(int pos)
        {
            Excel.Sheets excelSheets = xlBook.Worksheets;
            xlSheet = excelSheets.Item[pos];
            xlSheet.Activate();
            xlSheet.Visible = Excel.XlSheetVisibility.xlSheetVisible;
        }

        #region methods to write excel
        /// <summary>
        /// Write a single item to Excel...
        /// </summary>
        /// <param name="strItem">the item to write in excel</param>
        /// <param name="Row">the row position</param>
        /// <param name="Col">the column position</param>
        public void IOWriteItem(string strItem, int Row, int Col)
        {
            xlSheet.Cells[Row, Col] = strItem;
        }

        /// <summary>
        /// write list to excel. don't worry for the length of the list. 
        /// it will calculated automatically.
        /// </summary>
        /// <param name="lstString">the list of strings to write excel</param>
        /// <param name="Row">the row to start writing</param>
        /// <param name="Col">the column to start writing</param>
        /// <param name="dir">the direction where you want to write the excel, 'c' for top-down or 'r' for left-right</param>
        public void IOWriteList(List<string> lstString, int Row, int Col, char dir)
        {
            if (dir == 'c' || dir == 'r')
            {
                foreach (string s in lstString)
                {
                    xlSheet.Cells[Row, Col] = s;

                    if (dir == 'c')
                    {
                        Row++;
                    }
                    else
                    {
                        Col++;
                    }
                }
            }

        }

        /// <summary>
        /// writes a nested list into excel. don't worry for the length of the list. 
        /// it will calculated automatically.
        /// </summary>
        /// <param name="matData">the nested list of strings to write excel</param>
        /// <param name="Row">the row to start writing</param>
        /// <param name="Col">the column to start writing</param>
        /// <param name="swap">if is true will write first the row, if is false will write first the column</param>
        public void IOWriteMatrix(List<List<string>> matData, int Row, int Col, bool swap)
        {
            if (matData.Count > 0)
            {
                int origCol = Col;
                int origRow = Row;

                if (swap)
                {
                    foreach (List<string> lstString in matData)
                    {
                        Col = origCol;
                        foreach (string s in lstString)
                        {
                            xlSheet.Cells[Row, Col] = s;
                            Col++;
                        }
                        Row++;
                    }
                }
                else
                {
                    foreach (List<string> lstString in matData)
                    {
                        Row = origRow;
                        foreach (string s in lstString)
                        {
                            xlSheet.Cells[Row, Col] = s;
                            Row++;
                        }
                        Col++;
                    }
                }
            }
        }
        #endregion

        #region Methods to Open Excel
        /// <summary>
        /// open excel and display excel.
        /// </summary>
        public void IOWrite_OpenExcelApp()
        {
            excelApp = new Excel.Application();
            xlBook = excelApp.Workbooks.Open(filePath);
            excelApp.Visible = true;
        }

        /// <summary>
        /// open excel based on the constructor.
        /// </summary>
        /// <param name="display">if is true, show the excel"</param>
        public void IOWrite_OpenExcelApp(bool display, int sheetNum)
        {
            excelApp = new Excel.Application();
            xlBook = excelApp.Workbooks.Open(filePath);

            if (display)
            {
                excelApp.Visible = display;
                excelApp.WindowState = Excel.XlWindowState.xlMaximized;
            }
            int c = excelApp.Worksheets.Count; //check the sheetnumber...
            sheetNum = c;
            if ((sheetNum > c) || (sheetNum < 1)) //means we need to creates a new excel sheet.
            {
                xlSheet = (Excel.Worksheet)xlBook.Sheets.Add(Type.Missing, xlBook.Sheets[c], 1, Excel.XlSheetType.xlWorksheet);
                xlSheet.Name = "Gner8At_" + DateTime.Now.ToString("ss.fff");
            }
            else
            {
                xlSheet = xlBook.Sheets[sheetNum];
            }
        }

        /// <summary>
        /// open excel based on the constructor.
        /// </summary>
        /// <param name="display">if is true, show the excel"</param>
        public void IOWrite_OpenExcelApp(bool display)
        {
            excelApp = new Excel.Application();
            xlBook = excelApp.Workbooks.Open(filePath);

            if (display)
            {
                excelApp.Visible = display;
                excelApp.WindowState = Excel.XlWindowState.xlMaximized;
            }

            int c = excelApp.Worksheets.Count; //check the sheetnumber...
            sheetNum = c;
            if ((sheetNum > c) || (sheetNum < 1)) //means we need to creates a new excel sheet.
            {
                xlSheet = (Excel.Worksheet)xlBook.Sheets.Add(Type.Missing, xlBook.Sheets[c], 1, Excel.XlSheetType.xlWorksheet);
            }
            else
            {
                xlSheet = xlBook.Sheets[sheetNum];
            }
        }

        #endregion

        private void IOWrite_CreatesExcelApp(bool display)
        {
            excelApp = new Excel.Application();
            xlBook = excelApp.Workbooks.Add(misValue);
            excelApp.Visible = display;
        }

        /// <summary>
        /// clean all the marshalls and close the excel.
        /// </summary>
        /// <param name="saveFile">if is true, will save the file</param>
        public void CloseSaveExcelApp(string Path)
        {
            //clean up
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //release com objects to fully kill excell process
            if (xlRange != null)
            { Marshal.ReleaseComObject(xlRange); } //kill the range..

            if (xlSheet != null)
            { Marshal.ReleaseComObject(xlSheet); } //kill the sheet used

            if (xlBook != null)
            {
                xlBook.SaveAs(Path);
                xlBook.Close(true, misValue, misValue);
                Marshal.ReleaseComObject(xlBook); //kill the file
            }

            if (excelApp != null)
            {
                excelApp.Quit();
                Marshal.ReleaseComObject(excelApp); //kill the excel
            }
        }

        /// <summary>
        /// clean all the marshalls and close the excel.
        /// </summary>
        /// <param name="saveFile">if is true, will save the file</param>
        public void CloseExcelApp(bool saveFile)
        {
            //clean up
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //release com objects to fully kill excell process
            if (xlRange != null)
            { Marshal.ReleaseComObject(xlRange); } //kill the range..

            if (xlSheet != null)
            { Marshal.ReleaseComObject(xlSheet); } //kill the sheet used

            if (xlBook != null)
            {
                xlBook.Close(saveFile, Type.Missing, Type.Missing);
                Marshal.ReleaseComObject(xlBook); //kill the file
            }

            if (excelApp != null)
            {
                excelApp.Quit();
                Marshal.ReleaseComObject(excelApp); //kill the excel
            }
        }

    }
}
