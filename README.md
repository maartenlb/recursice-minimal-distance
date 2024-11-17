# Closest Pair of Points Calculator

## Overview
This C# program reads a list of coordinates and calculates the two points with the minimum distance between them. The algorithm is implemented recursively to achieve an **O(n log n)** time complexity, making it suitable for real-world applications where performance is critical. A naive comparison algorithm with **O(n²)** complexity would be too slow for large datasets.

## Algorithm Details

### Overview
This program implements the **Divide and Conquer** approach to solve the Closest Pair of Points problem. The algorithm achieves \( O(n \log n) \) time complexity by leveraging efficient sorting and recursive partitioning of the dataset.

### Step-by-Step Breakdown
1. **Sorting**:
   - The algorithm starts by sorting the list of points by their **x-coordinates**. This initial sorting step takes \( O(n \log n) \).

2. **Divide and Conquer**:
   - **Divide**: The sorted list is recursively divided into two halves, splitting at the midpoint by x-coordinate.
   - **Conquer**:
     - The closest pair of points in the **left half** and the **right half** are computed recursively.
     - The minimum distance (\( d \)) between pairs in each half is retained.

3. **Merge (Strip Step)**:
   - A "strip" region around the dividing line (within distance \( d \)) is constructed.
   - Only points within \( d \) in the y-coordinate are considered, reducing comparisons significantly.
   - The strip is processed by comparing each point with the next few points in sorted y-order, up to \( \min(7) \) comparisons per point. This step runs in linear time \( O(n) \).

### Key Insights for \( O(n \log n) \) Complexity
- **Divide**: Dividing the points into two halves takes constant time.
- **Recursive Conquer**: Each recursive call operates on half the points, leading to a recurrence relation of:
  \[
  T(n) = 2T\left(\frac{n}{2}\right) + O(n)
  \]
  This simplifies to \( O(n \log n) \) using the Master Theorem.

- **Efficient Comparisons in Merge**:
  - The strip is processed in \( O(n) \) because the number of relevant comparisons is bounded by a constant (\( \min(7) \)) for each point.

### Why It’s Faster Than \( O(n^2) \)
- The naive brute-force approach involves comparing every point to every other point, resulting in \( O(n^2) \) comparisons.
- By dividing the problem and only merging a small subset of points, the divide-and-conquer algorithm dramatically reduces unnecessary comparisons, achieving \( O(n \log n) \).

---

## Expanding to 3D or Higher Dimensions

The divide-and-conquer approach can be extended to 3D or higher-dimensional spaces with minimal modifications:

### Key Adjustments
1. **Sorting**:
   - Instead of sorting only by the x-coordinate, sort by one of the coordinates (e.g., x) as the primary axis.
   - Use additional coordinate data (e.g., y, z for 3D) during the merge step.

2. **Strip Step in Higher Dimensions**:
   - In 3D, the "strip" becomes a volume centered around the dividing plane within a distance \( d \).
   - Points in this strip are sorted by their secondary coordinate (e.g., y).
   - Comparisons are made within this strip volume, reducing the number of comparisons per point, similar to 2D.

3. **Time Complexity**:
   - The time complexity remains \( O(n \log n) \) because the divide-and-conquer logic and the linear-time merge step extend naturally to higher dimensions.
   - While the constant factor increases slightly due to more comparisons in higher dimensions, the asymptotic complexity does not change.

### Example Applications
- **3D Space**: Finding the closest pair of stars in a galaxy (x, y, z coordinates).
- **n-Dimensional Space**: Applications in machine learning or optimization problems involving feature spaces with many dimensions.

### Implementation Notes
- The recursive framework and merge logic are easily adaptable to n-dimensional spaces by generalizing coordinate comparisons.
- For \( d \)-dimensional data, the "strip" processing logic will require comparisons within a \( d \)-dimensional region, but the underlying divide-and-conquer structure remains unchanged.

This adaptability makes the algorithm highly versatile for practical applications in computational geometry and related fields.


## Usage
1. **Input**:  
   - Provide a list of 2D coordinates (e.g., from a file or directly in the code).

2. **Execution**:  
   - Compile and run the program using a C# compiler or IDE.

   ```bash
   dotnet run
