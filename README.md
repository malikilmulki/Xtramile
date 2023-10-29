# Xtramile
**Xtramile Solution**
**Basic Algorithm test. This test should be done in 30 mins (you can do it whenever you're ready)**
  >TASK #1
  
  ##Write a method or pseudocode that finds, efficiently with respect to time used, all numbers that
  occur exactly once in the input collection.
  For example, findUniqueNumbers(Array.asList(1, 2, 1, 3 )) should return { 2, 3 }.
  
  Answer :
  ```
  public List<int> FindUniqueNumbers(List<int> items)
  {  	
     if(items != null && items.Any())
       return items.Distinct().ToList();
  	  return new List<int>();
   }
  ```
  
  
  >TASK #2
  
  Implement the findMaxSum method or pseudocode that, efficiently with respect to time used,
  returns the largest sum of any two elements in the given list of positive numbers.
  For example, the largest sum of the list { 5, 9, 7, 11 } is the sum of the elements 9 and 11, which
  is 20.
  
  Answer :
  ```
  public int LargestSum(List<int> items)
  {
  	int result = 0;
  	if(items != null && items.Any())
  	{
  		if(items.Count > 1
  		{
  			var orderedItems = items.OrderByDescending().ToList();
  			result = orderedItems[0] + orderedItems[1] 
  		}
  		else
  			result = items[0];
  	}
  	return result;
  }
  ```

**Practical Test. You have 48hrs to finish this test, and should return to me on Sunday, 29th Oct 2023 at the latest.**

>TASK #1:

Data structure problem solving 
  Assuming we have a large set of patients (500,000+) in a relational database, we want the user
  to type part of a patient name and the system returns a list of matched patients.
  
  • What data structure and search/matching algorithm to use and why?
  
  Using binary search algorithm to do while searching. it will divide the search interval in half. the idea is to use information that the array is sorted and reduce the time complexity
  
  • How fast the search is using this algorithm and data structure?
  
  it will divide the search interval in half. the idea is to use information that the array is sorted and reduce the time complexity

>TASK #2: Design and coding
in this repository
