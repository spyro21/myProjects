using System;
					
public class Program
{
	public static void Main()
	{
		//               0 1 2 3
		int[,] board = {{0,3,0,1}, //0         
		 				{0,0,2,0}, //1
		 				{0,4,0,0}, //2
						{3,0,1,0}};//3
		/*
		2 3 4 1
		4 1 2 3
		1 4 3 2
		3 2 1 4
		
		{{0,3,0,1}, //0         
		 {0,0,2,0}, //1
		 {0,4,0,0}, //2
		 {3,0,1,0}};//3
		*/
		
		bool solved = false;
		String strInput;
		int rowIn = -1;
		int colIn = -1;
		printBoard(board,4);
		int[] testArr = {1,2,3,4};
		Console.WriteLine(checkForUnique(testArr));
		
		while(!solved)	
		{
			Console.WriteLine("add or delete?");
			strInput = Console.ReadLine();
			strInput.ToLower();
			
			switch (strInput) 
			{
				case "add":
					Console.WriteLine("row?");
					rowIn = int.Parse(Console.ReadLine());
					Console.WriteLine("col?");
					colIn = int.Parse(Console.ReadLine());
					
					Console.WriteLine("num?");
					board[rowIn,colIn] = int.Parse(Console.ReadLine());
					
					break;
					
				case "delete":
					Console.WriteLine("row?");
					rowIn = int.Parse(Console.ReadLine());
					Console.WriteLine("col?");
					colIn = int.Parse(Console.ReadLine());
					
					board[rowIn,colIn] = 0;
					
					break;
				
			}
			printBoard(board,4);
			
			if(checkBoard(board)){
				solved = true;
			}
			
			
		} // end of while loop
		
		//congrats
		Console.WriteLine();
		Console.WriteLine("you solved it!");
		Console.WriteLine();
	}
	
	public static bool checkForUnique(int[] arr) 
	{
		
		for(int i = 0 ; i < 4;i++)
		{
			if(arr[i] == 0)
			{
				 return false;
			}
		}
		
		for(int i = 0; i < 4;i++) 
		{
			for(int k = 0;k < 4;k++) 
			{
				if(arr[i] == arr[k] && (i != k)) 
				{
					return false;
				}
			}
		}
		return true;
	}
	
	
	
	public static bool checkBoard(int[,] arr) 
	{
		int[] nextCheck = {0,0,0,0};
		
		for(int row = 0; row < 4; row++){
			if(checkForUnique(getRow(arr,row)) == false){
				return false;
			}
		}
		
		for(int col = 0; col < 4; col++){
			if(checkForUnique(getCol(arr,col)) == false){
				return false;
			}
		}
		
		int[] diagonal1={arr[0,0],arr[1,1],arr[2,2],arr[3,3]};
		int[] diagonal2={arr[0,3],arr[1,2],arr[2,1],arr[3,0]};
		if(!checkForUnique(diagonal1) && !checkForUnique(diagonal2))
		{
				return false;
		}
		
		int[] sector1 = {arr[0,0],arr[0,1],arr[1,0],arr[1,1]};
		int[] sector2 = {arr[0,2],arr[0,3],arr[1,2],arr[1,3]};
		int[] sector3 = {arr[2,0],arr[2,1],arr[3,0],arr[3,1]};
		int[] sector4 = {arr[2,2],arr[2,3],arr[3,2],arr[3,3]};
		if(!checkForUnique(sector1) && !checkForUnique(sector2) &&
		   !checkForUnique(sector3) && !checkForUnique(sector4)){
			return false;
		}
		return true;
	}
	
	
	
	public static int[] getRow(int[,] arr,int n) 
	{
		int[] returnArr = {0,0,0,0};
		for(int i = 0; i < 4;i++)
		{
			returnArr[i] = arr[n,i];
		}
		return returnArr;
	}
	
	
	
	public static int[] getCol(int[,] arr,int n) 
	{
		int[] returnArr = {0,0,0,0};
		for(int i = 0; i < 4;i++)
		{
			returnArr[i] = arr[i,n];
		}
		return returnArr;
	}
	
	
	
	public static void printBoard(int[,] arr, int size)
	{
		for(int row = 0; row < size;row++)
		{
			Console.WriteLine();
			for(int col = 0; col < size;col++)
			{
				Console.Write(" " + arr[row,col]+ " ");
			}
		}
		Console.WriteLine();
	}
}
