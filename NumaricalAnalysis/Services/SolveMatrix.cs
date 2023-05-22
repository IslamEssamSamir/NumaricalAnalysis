using NumaricalAnalysis.Models;
using NumaricalAnalysis.Services;

namespace NumaricalAnalysis.Helpers
{
    public enum RowNumber { FirstRow, SecondRow, ThirdRow };
    public enum ColumnNumber { FirstColumn, SecondColumn, ThirdColumn };
    public class SolveMatrix : ISolveMatrix
    {





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


        public List<ChapterTwoResult> LUDecomposition(double[,] matrix, bool IsPivoting, double[]  matrixC, double[] matrixX)
        {
            List<ChapterTwoResult> result = new List<ChapterTwoResult>();
            double[] matrixB = new double[3];
            ChapterTwoResult resultObj;
            double m21, m31, m32;


            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = matrix.GetLength(1) - 1; j < matrix.GetLength(1); j++)
                {
                    matrixB[i] = matrix[i, j];
                }
            }


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
            resultObj.UpperOrLowerMatrix = "Upper Matrix";

            CopyTo(matrix, resultObj.Matrix);
            result.Add(resultObj);


            resultObj = new ChapterTwoResult();
            double[,] MatrixL = new double[3, 3] { { 1, 0, 0 }, { m21, 1, 0 }, { m31, m32, 1 } };
            resultObj.UpperOrLowerMatrix = "Lower Matrix";
            CopyTo(MatrixL, resultObj.Matrix);
            result.Add(resultObj);

            double c1 = matrixB[0];
            double c2 = matrixB[1] - (c1 * m21);
            double c3 = matrixB[2] - (c1 * m31) + (c2 * m32);


            matrixC[0] = c1;
            matrixC[1] = c2;
            matrixC[2] = c3;

            double x3 = matrix[2,3] / matrix[2,2];
            double x2 = (c2 - (matrix[1, 2] * x3)) / matrix[1, 1];
            double x1 = ((c1-(matrix[0, 2]*x3)+ matrix[0, 1] * x2)) / matrix[0,0];

            matrixX[0] = x1;
            matrixX[1] = x2;
            matrixX[2] = x3;
                   




            return result;

        }

        public List<ChapterTwoResult> CramerRule(double[,] matrix, out double x1, out double x2, out double x3)
        {
            List<ChapterTwoResult> result = new List<ChapterTwoResult>();
            (double NumericalResult, string TextResult) A, A1, A2, A3;

            double[,] matrixA = new double[3, 3];
            double[] matrixB = new double[3];


            double[,] matrixC = new double[3, 3];
            ChapterTwoResult ResultObj;


            //  -------------------------------  Matrix Ax = B  -------------------------------
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    matrixA[i, j] = matrix[i, j];
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = matrix.GetLength(1) - 1; j < matrix.GetLength(1); j++)
                {
                    matrixB[i] = matrix[i, j];
                }
            }
            //-----------------------------------------------------------------------------------





            //  -------------------------------  Matrix A  -------------------------------
            ResultObj = new ChapterTwoResult();

            A = ReturnMatrixResult(matrixA);

            ResultObj.ResultStep = A.TextResult;
            CopyTo(matrixA, ResultObj.Matrix);
            result.Add(ResultObj);

            //-----------------------------------------------------------------------------------







            //  -------------------------------  Matrix A1  -------------------------------
            ResultObj = new ChapterTwoResult();
            matrixC = GetNewAugmentedMatrix(matrixA, matrixB, ColumnNumber.FirstColumn);

            A1 = ReturnMatrixResult(matrixC);

            ResultObj.ResultStep = A1.TextResult;
            CopyTo(matrixC, ResultObj.Matrix);
            result.Add(ResultObj);


            //-----------------------------------------------------------------------------------



            //  -------------------------------  Matrix A2  -------------------------------
            ResultObj = new ChapterTwoResult();
            matrixC = GetNewAugmentedMatrix(matrixA, matrixB, ColumnNumber.SecondColumn);

            A2 = ReturnMatrixResult(matrixC);

            ResultObj.ResultStep = A2.TextResult;
            CopyTo(matrixC, ResultObj.Matrix);
            result.Add(ResultObj);


            //-----------------------------------------------------------------------------------



            //  -------------------------------  Matrix A3  -------------------------------
            ResultObj = new ChapterTwoResult();
            matrixC = GetNewAugmentedMatrix(matrixA, matrixB, ColumnNumber.ThirdColumn);

            A3 = ReturnMatrixResult(matrixC);

            ResultObj.ResultStep = A3.TextResult;
            CopyTo(matrixC, ResultObj.Matrix);
            result.Add(ResultObj);


            //-----------------------------------------------------------------------------------

            x1 = A1.NumericalResult / A.NumericalResult;
            x2 = A2.NumericalResult / A.NumericalResult;
            x3 = A3.NumericalResult / A.NumericalResult;



            return (result);
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
                        
                        if (Math.Abs(matrix[i, (int)columnNumber]) > Math.Abs(matrix[(int)RowOfMaxValue, (int)columnNumber]) )
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

        private void CopyTo(double[,] matrix, double[,] copyToThisMatrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    copyToThisMatrix[i, j] = matrix[i, j];
                }
            }
        }

        private double[,] GetNewAugmentedMatrix(double[,] matrixA, double[] matrixB, ColumnNumber columnNumber)
        {
            double[,] matrixC = new double[matrixA.GetLength(0), matrixA.GetLength(1)];
            CopyTo(matrixA, matrixC);
            for (int i = 0; i < matrixA.GetLength(0); i++)
            {
                matrixC[i, (int)columnNumber] = matrixB[i];
            }

            return matrixC;
        }

        /// <summary>
        /// for matrix 3*3 only.
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        private (double, string) ReturnMatrixResult(double[,] matrix)
        {
            double doubleResult =
                ((matrix[0, 0] * ((matrix[1, 1] * matrix[2, 2]) - (matrix[1, 2] * matrix[2, 1])))
                - (matrix[0, 1] * ((matrix[1, 0] * matrix[2, 2]) - (matrix[1, 2] * matrix[2, 0])))
                + (matrix[0, 2] * ((matrix[1, 0] * matrix[2, 1]) - (matrix[1, 1] * matrix[2, 0]))));



            string stringResult = $"( {matrix[0, 0]}({(matrix[1, 1] * matrix[2, 2])} - {(matrix[1, 2] * matrix[2, 1])}) )   -  ( {matrix[0, 1]}({(matrix[1, 0] * matrix[2, 2])} - {(matrix[1, 2] * matrix[2, 0])})  ) +  ( {matrix[0, 2]}({(matrix[1, 0] * matrix[2, 1])} - {(matrix[1, 1] * matrix[2, 0])}) )" +
                $" = {(matrix[0, 0] * ((matrix[1, 1] * matrix[2, 2]) - (matrix[1, 2] * matrix[2, 1])))} - {(matrix[0, 1] * ((matrix[1, 0] * matrix[2, 2]) - (matrix[1, 2] * matrix[2, 0])))} + {(matrix[0, 2] * ((matrix[1, 0] * matrix[2, 1]) - (matrix[1, 1] * matrix[2, 0])))} = {doubleResult} ";


            return (doubleResult, stringResult);

        }


    }
}
