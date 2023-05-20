using NumaricalAnalysis.Models;
using NumaricalAnalysis.Services;

namespace NumaricalAnalysis.Helpers
{
    public enum RowNumber { FirstRow, SecondRow, ThirdRow };
    public enum ColumnNumber { FirstColumn, SecondColumn };
    public class SolveMatrix : ISolveMatrix
    {

        //use services instead os static class ...
        public List<ChapterTwoResult> GaussElimination(double[,] matrix, bool IsPivoting)
        {
            List<ChapterTwoResult> result = new List<ChapterTwoResult>();
            ChapterTwoResult resultObj;
            double m21, m31, m32;

            //step1
            if (IsPivoting)
            {
                Pivote(matrix, ColumnNumber.FirstColumn);
                resultObj = new ChapterTwoResult();
                CopyTo(matrix, resultObj.Matrix);
                result.Add(resultObj);
            }
            m21 = matrix[1, 0] / matrix[0, 0];
            resultObj = new ChapterTwoResult
            {
                Multiplier = $"m21 = {matrix[1, 0]} / {matrix[0, 0]} = {m21}",
                ResultStep = "R2 -->  R2 - (m21 * R1)"
            };
            ApplyRoleOnRow(matrix, RowNumber.SecondRow, RowNumber.FirstRow, m21);
            //resultObj.Matrix = matrix; note: array is refernce value   (logical error)  

            CopyTo(matrix, resultObj.Matrix);

            result.Add(resultObj);


            //step 2 
            m31 = matrix[2, 0] / matrix[0, 0];
            resultObj = new ChapterTwoResult
            {
                Multiplier = $"m31 = {matrix[2, 0]} / {matrix[0, 0]} = {m31}",
                ResultStep = "R3 -->  R3 - (m31 * R1)"
            };
            ApplyRoleOnRow(matrix, RowNumber.ThirdRow, RowNumber.FirstRow, m31);
            //resultObj.Matrix = matrix; note: array is refernce value   (logical error)  
            CopyTo(matrix, resultObj.Matrix);
            result.Add(resultObj);


            //step3
            if (IsPivoting)
            {
                Pivote(matrix, ColumnNumber.SecondColumn);
                resultObj = new ChapterTwoResult();
                CopyTo(matrix, resultObj.Matrix);
                result.Add(resultObj);
            }
            m32 = matrix[2, 1] / matrix[1, 1];
            resultObj = new ChapterTwoResult
            {
                Multiplier = $"m21 = {matrix[2, 1]} / {matrix[1, 1]} = {m32}",
                ResultStep = "R3 -->  R3 - (m32 * R2)"
            };
            ApplyRoleOnRow(matrix, RowNumber.ThirdRow, RowNumber.SecondRow, m32);
            //resultObj.Matrix = matrix; note: array is refernce value   (logical error)  
            CopyTo(matrix, resultObj.Matrix);
            result.Add(resultObj);


           




            return result;
        }

        private void SwapRow(double[,] matrix, RowNumber row1, RowNumber row2)
        {
            int firstRow = (int)row1;
            int secondRow = (int)row2;


            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                double temp = 0;
                temp = matrix[firstRow, i];
                matrix[firstRow, i] = matrix[secondRow, i];
                matrix[secondRow, i] = temp;

            }

        }

        private bool Pivote(double[,] matrix, ColumnNumber columnNumber)
        {
            RowNumber RowOfMaxValue;
            double maxValue;
            switch (columnNumber)
            {
                case ColumnNumber.FirstColumn:

                    RowOfMaxValue = RowNumber.FirstRow;
                    maxValue = matrix[0, 0];
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        if (matrix[i, (int)columnNumber] > matrix[(int)RowOfMaxValue, (int)columnNumber])
                            RowOfMaxValue = (RowNumber)i;
                    }

                    if (RowOfMaxValue != RowNumber.FirstRow)
                        SwapRow(matrix, RowNumber.FirstRow, RowOfMaxValue);
                    return true;


                case ColumnNumber.SecondColumn:

                    RowOfMaxValue = RowNumber.SecondRow;
                    maxValue = matrix[0, 0];
                    for (int i = 1; i < matrix.GetLength(0); i++)
                    {
                        if (matrix[i, (int)columnNumber] > matrix[(int)RowOfMaxValue, (int)columnNumber])
                            RowOfMaxValue = (RowNumber)i;
                    }

                    if (RowOfMaxValue != RowNumber.FirstRow)
                        SwapRow(matrix, RowNumber.SecondRow, RowOfMaxValue);
                    return true;

                default: return false;


            }
        }
        /// <summary>
        /// R2--> R2- m21( no. convert to zero / diagonal element ) * R1 (row of diagonal element)
        /// </summary>
        /// <param name="matrix"></param> 
        /// <param name="rowNum"></param> R2 (Row)
        /// <param name="rowMultipliedByM"></param> R1 (row of diagonal element)
        /// <param name="multiplyNum_M"></param> m21( no. convert to zero / diagonal element )
        private void ApplyRoleOnRow(double[,] matrix, RowNumber rowNum, RowNumber rowMultipliedByM, double multiplyNum_M)
        {
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                matrix[(int)rowNum, i] -= (matrix[(int)rowMultipliedByM, i] * multiplyNum_M);
            }
        }

        private void CopyTo(double[,] matrix , double[,] copyToThisMatrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    copyToThisMatrix[i, j] = matrix[i, j];
                }
            }
        }

    }
}
