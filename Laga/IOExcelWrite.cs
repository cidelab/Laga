using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.IO;
//using Excel = Microsoft.Office.Interop.Excel;
/*
namespace Laga.IO
{
    /// <summary>
    /// Write data in excel
    /// </summary>
    public class IOExcelWrite
    {
        private string filePath;
        private int sheetNum;

        private Excel.Application excelApp;
        private Excel.Workbook xlBook;
        private Excel.Worksheet xlSheet;
        private Excel.Range xlRange;

        private List<List<string>> dataExcel = new List<List<string>>();
        private List<string> lstDataExcel = new List<string>();
        private object misValue = System.Reflection.Missing.Value;

        #region public properties

        /// <summary>
        /// Get and set the excel range.
        /// </summary>
        public Excel.Range XlRange
        {
            set
            {
                value = xlRange;
            }
            get
            {
                return xlRange;
            }
        }

        /// <summary>
        /// get the sheet number 
        /// </summary>
        public int SheetNum
        {
            get
            {
                return sheetNum;
            }
        }

        /// <summary>
        /// Set a nested list of strings.
        /// </summary>
        public List<List<string>> MatrixDataExcel
        {
            set
            {
                dataExcel = value;
            }
        }

        /// <summary>
        /// Set a nested list of strings.
        /// </summary>
        public List<string> ListDataExcel
        {
            set
            {
                lstDataExcel = value;
            }
        }

        /// <summary>
        /// check if the file exists.
        /// </summary>
        /// <param name="path">the path to the excel file</param>
        /// <returns>bool</returns>
        public static bool CheckExcelFile(string path)
        {
            return File.Exists(path);
        }

        #endregion

        #region constructors
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
        /// <param name="FilePath">adress to the file</param>
        public IOExcelWrite(string FilePath)
        {
            this.filePath = FilePath;
            if(IOExcel.TestExcelOpen(filePath, out xlBook))
            {
                xlSheet = xlBook.ActiveSheet;
            }
        }

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
        #endregion

        /// <summary>
        /// Creates and excel sheet to write on.
        /// </summary>
        /// <param name="pos">The sheet position number</param>
        /// <param name="name">The sheet name name</param>
        public void IOWrite_NewExcelSheet(int pos, string name)
        {
     
            xlSheet = (Excel.Worksheet)xlBook.Sheets.Add(Type.Missing, xlBook.Sheets[pos], 1, Excel.XlSheetType.xlWorksheet);
            xlSheet.Name = name;
        }

        /// <summary>
        /// Activates a specific Excel sheet to write on.
        /// </summary>
        /// <param name="pos">The position of the excel sheet in the document.</param>
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
        /// <param name="Row">The row position</param>
        /// <param name="Col">The column position</param>
        public void IOWriteItem(string strItem, int Row, int Col)
        {
            xlSheet.Cells[Row, Col] = strItem;
        }

        /// <summary>
        /// Write a list of strings in excel. the list length is calculated automatically.
        /// </summary>
        /// <param name="lstString">The list of strings to write</param>
        /// <param name="Row">The row position</param>
        /// <param name="Col">The column position</param>
        /// <param name="dir">The writing direction, 'c' for top-down or 'r' for left-right</param>
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
        /// Write a nested list of strings in excel. The list length is calculated automatically.
        /// </summary>
        /// <param name="matData">The nested list of strings to write</param>
        /// <param name="Row">The row position</param>
        /// <param name="Col">The column position</param>
        /// <param name="swap">If true, write first the row, if false write first the column</param>
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
        /// Open an Excel document and display the document.
        /// </summary>
        public void IOWrite_OpenExcelApp()
        {
            excelApp = new Excel.Application();
            xlBook = excelApp.Workbooks.Open(filePath);
            excelApp.Visible = true;
        }

        /// <summary>
        /// Open an Excel document based on the constructor.
        /// </summary>
        /// <param name="display">Show the app</param>
        /// <param name="sheetNum">open the sheetnumber</param>
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
        /// Open an Excel document based on the constructor.
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
        /// Save the Excel file and close safely the Excel application.
        /// </summary>
        /// <param name="Path">The file name</param>
        public void SaveCloseExcelApp(string Path)
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
        /// Close safely the Excel application and decide to save or not.
        /// </summary>
        /// <param name="saveFile">If true, the Excel file is saved.</param>
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

*/