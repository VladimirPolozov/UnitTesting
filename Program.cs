using System;
using System.Collections.Generic;
using static MatrixCalculator.SquareMatrix;

namespace MatrixCalculator
{
  public class SquareMatrix : IComparable<SquareMatrix>
  {
    public delegate SquareMatrix DiagonalizeMatrixDelegate(SquareMatrix matrix);
    public delegate SquareMatrix MatrixOperationDelegate(SquareMatrix firstMatrix, SquareMatrix secondMatrix);
    public delegate bool MatrixComparisonDelegate(SquareMatrix firstMatrix, SquareMatrix secondMatrix);
    public int Extension
    {
      get
      {
        return (int)Math.Sqrt(MatrixArray.Length);
      }
    }
    public int[,] MatrixArray { get; set; }
    private int hash;
    public int Hash
    {
      get
      {
        hash = MatrixArray[0, 0];

        for (int rowIndex = 0; rowIndex < Extension; ++rowIndex)
        {
          for (int columnIndex = 0; columnIndex < Extension; ++columnIndex)
          {
            hash = hash * MatrixArray[rowIndex, columnIndex] + hash % MatrixArray[rowIndex, columnIndex];
          }
        }

        return hash;
      }
    }

    public SquareMatrix(int[,] elements)
    {
      MatrixArray = elements;
    }

    public SquareMatrix(int[][] elements)
    {
      MatrixArray = GetMatrixFromArrayOfArrays(elements);
    }

    public SquareMatrix(params int[] elements)
    {
      MatrixArray = GetMatrixFromArray(elements);
    }

    public int[,] GetMatrixFromArray(int[] elements)
    {
      int extension = (int)Math.Sqrt(elements.Length);
      int[,] matrix = new int[extension, extension];
      int elementIndex = 0;

      for (int rowIndex = 0; rowIndex < extension; ++rowIndex)
      {
        for (int columnIndex = 0; columnIndex < extension; ++columnIndex)
        {

          try
          {
            matrix[rowIndex, columnIndex] = elements[elementIndex];
          }
          catch (System.IndexOutOfRangeException exception)
          {
            Console.WriteLine(exception.Message);
          }

          ++elementIndex;
        }
      }

      return matrix;
    }

    public int[,] GetMatrixFromArrayOfArrays(int[][] elements)
    {
      int extension = (int)Math.Sqrt(elements.Length);
      int[,] matrix = new int[extension, extension];

      for (int rowIndex = 0; rowIndex < extension; ++rowIndex)
      {
        for (int columnIndex = 0; columnIndex < extension; ++columnIndex)
        {
          matrix[rowIndex, columnIndex] = elements[rowIndex][columnIndex];
        }
      }

      return matrix;
    }

    public void AutoFill(int extension, int minElement = -10, int maxElement = 10)
    {
      int[] elements = new int[extension * extension];
      var random = new Random();

      for (int elementIndex = 0; elementIndex < extension * extension; ++elementIndex)
      {
        elements[elementIndex] = random.Next(minElement, maxElement);
      }

      MatrixArray = GetMatrixFromArray(elements);
    }

    public SquareMatrix Clone()
    {
      int[,] elements = new int[this.Extension, this.Extension];

      for (int rowIndex = 0; rowIndex < this.Extension; ++rowIndex)
      {
        for (int columnIndex = 0; columnIndex < this.Extension; ++columnIndex)
        {
          elements[rowIndex, columnIndex] = this.MatrixArray[rowIndex, columnIndex];
        }
      }

      return new SquareMatrix(elements);
    }

    public int SumOfElements()
    {
      int sumOfElements = 0;

      for (int rowIndex = 0; rowIndex < this.Extension; ++rowIndex)
      {
        for (int columnIndex = 0; columnIndex < this.Extension; ++columnIndex)
        {
          sumOfElements += this.MatrixArray[rowIndex, columnIndex];
        }
      }

      return sumOfElements;
    }

    public static SquareMatrix operator +(SquareMatrix firstMatrix, SquareMatrix secondMatrix)
    {
      if (firstMatrix.Extension != secondMatrix.Extension)
      {
        throw new DifferentSizesException("Операцию сложения можно выполнять только с матрицами одинаковой размерности");
      }

      var result = firstMatrix.Clone();
      int extension = firstMatrix.Extension;

      for (int rowIndex = 0; rowIndex < extension; ++rowIndex)
      {
        for (int columnIndex = 0; columnIndex < extension; ++columnIndex)
        {
          result.MatrixArray[rowIndex, columnIndex] += secondMatrix.MatrixArray[rowIndex, columnIndex];
        }
      }

      return result;
    }

    public static SquareMatrix operator -(SquareMatrix firstMatrix, SquareMatrix secondMatrix)
    {
      if (firstMatrix.Extension != secondMatrix.Extension)
      {
        throw new DifferentSizesException("Операцию вычитания можно выполнять только с матрицами одинаковой размерности");
      }

      var result = firstMatrix.Clone();
      int extension = firstMatrix.Extension;

      for (int rowIndex = 0; rowIndex < extension; ++rowIndex)
      {
        for (int columnIndex = 0; columnIndex < extension; ++columnIndex)
        {
          result.MatrixArray[rowIndex, columnIndex] -= secondMatrix.MatrixArray[rowIndex, columnIndex];
        }
      }

      return result;
    }

    public static SquareMatrix operator *(SquareMatrix firstMatrix, SquareMatrix secondMatrix)
    {
      if (firstMatrix.Extension != secondMatrix.Extension)
      {
        throw new DifferentSizesException("Операцию умножения можно выполнять только с матрицами одинаковой размерности");
      }

      var result = firstMatrix.Clone();
      int extension = firstMatrix.Extension;

      for (int rowIndexOfFirstMatrix = 0; rowIndexOfFirstMatrix < firstMatrix.Extension; ++rowIndexOfFirstMatrix)
      {
        for (int columnIndex = 0; columnIndex < extension; ++columnIndex)
        {
          result.MatrixArray[rowIndexOfFirstMatrix, columnIndex] = 0;

          for (int indexOfSecondElement = 0; indexOfSecondElement < extension; ++indexOfSecondElement)
          {
            result.MatrixArray[rowIndexOfFirstMatrix, columnIndex] += firstMatrix.MatrixArray[rowIndexOfFirstMatrix, indexOfSecondElement] * secondMatrix.MatrixArray[indexOfSecondElement, columnIndex];
          }
        }
      }

      return result;
    }

    public int CompareTo(SquareMatrix other)
    {
      if (this.Extension == other.Extension)
      {
        if (this.SumOfElements() > other.SumOfElements())
        {
          return 1;
        }
        else if (this.SumOfElements() == other.SumOfElements())
        {
          return 0;
        }
        else if (this.SumOfElements() < other.SumOfElements())
        {
          return -1;
        }
      }
      return -1;
    }

    public static bool operator >(SquareMatrix firstMatrix, SquareMatrix secondMatrix)
    {
      return firstMatrix.CompareTo(secondMatrix) > 0;
    }

    public static bool operator <(SquareMatrix firstMatrix, SquareMatrix secondMatrix)
    {
      return firstMatrix.CompareTo(secondMatrix) < 0;
    }

    public static bool operator >=(SquareMatrix firstMatrix, SquareMatrix secondMatrix)
    {
      return firstMatrix.CompareTo(secondMatrix) >= 0;
    }

    public static bool operator <=(SquareMatrix firstMatrix, SquareMatrix secondMatrix)
    {
      return firstMatrix.CompareTo(secondMatrix) <= 0;
    }

    public override bool Equals(object other)
    {
      var second = other as SquareMatrix;
      return this.SumOfElements() == second.SumOfElements();
    }

    public static bool operator ==(SquareMatrix firstMatrix, SquareMatrix secondMatrix)
    {
      return Object.Equals(firstMatrix, secondMatrix);
    }

    public static bool operator !=(SquareMatrix firstMatrix, SquareMatrix secondMatrix)
    {
      return !Object.Equals(firstMatrix, secondMatrix);
    }

    public static bool operator false(SquareMatrix matrix)
    {
      return matrix.SumOfElements() == 0;
    }

    public static bool operator true(SquareMatrix matrix)
    {
      return matrix.SumOfElements() == 1;
    }

    public override int GetHashCode()
    {
      return this.Hash;
    }

    public override string ToString()
    {
      string matrixString = "";

      for (int rowIndex = 0; rowIndex < this.Extension; ++rowIndex)
      {
        for (int columnIndex = 0; columnIndex < this.Extension; ++columnIndex)
        {
          if (MatrixArray[rowIndex, columnIndex] < 0 || MatrixArray[rowIndex, columnIndex] > 9)
          {
            matrixString += " " + MatrixArray[rowIndex, columnIndex];
          }
          else
          {
            matrixString += "  " + MatrixArray[rowIndex, columnIndex];
          }
        }
        matrixString += "\n";
      }

      return matrixString;
    }

    public static implicit operator SquareMatrix(int[] elements)
    {
      return new SquareMatrix(elements);
    }

    public static explicit operator string(SquareMatrix matrix)
    {
      return matrix.ToString();
    }

    public static explicit operator int[,](SquareMatrix matrix)
    {
      return matrix.MatrixArray;
    }

    public static int CalculateDeterminant(SquareMatrix matrix)
    {
      if (matrix.Extension == 1)
      {
        return matrix.MatrixArray[0, 0];
      }

      int determinant = 0;

      for (int columnIndex = 0; columnIndex < matrix.Extension; ++columnIndex)
      {
        int minorDeterminant = matrix.MatrixArray[0, columnIndex] * CalculateDeterminant(CalculateMinor(matrix.MatrixArray, 0, columnIndex));
        determinant += (columnIndex % 2 == 0) ? minorDeterminant : -minorDeterminant;
      }

      return determinant;
    }

    public static SquareMatrix CalculateMinor(int[,] matrix, int excludedRow, int excludedColumn)
    {
      int[][] minor = new int[matrix.Length - 1][];
      int minorIndex = 0;

      for (int rowIndex = 0; rowIndex < matrix.Length; ++rowIndex)
      {
        if (rowIndex == excludedRow)
          continue;

        List<int> minorRow = new List<int>();

        for (int columnIndex = 0; columnIndex < matrix.Length; ++columnIndex)
        {
          if (columnIndex == excludedColumn)
            continue;

          minorRow.Add(matrix[rowIndex, columnIndex]);
        }

        minor[minorIndex++] = minorRow.ToArray();
      }

      return new SquareMatrix(minor);
    }
  }

  class DifferentSizesException : System.Exception
  {
    public DifferentSizesException() : base() { }
    public DifferentSizesException(string message) : base(message) { }
    public DifferentSizesException(string message, System.Exception inner) : base(message, inner) { }
  }

  public class Progamm
  {
    public static void Main()
    {
    }
  }
}