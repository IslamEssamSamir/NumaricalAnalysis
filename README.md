# Numarical Analysis Project



                                                                                       


Numerical Analysis Web Application





 
## Introduction

### Introduction

It’s a web application which finding the roots of polynomials and solve linear algebric equation by of matrices .

Technologies/Techniques
we used different tools in Implementation Phase for Front-End and Back-End:
As a Front-End: we used HTML and CSS Template.
•	HTML (Hyper Text Markup Language)
•	CSS ( Cascading Style Sheets )
•	JQuery ( Javascript Library )
•	Bootstrap v.5
As a Back-End:
•	ASP.NET 6 (MVC) Design Pattern
 
## Chapter 1

### Bisection Method

The bisection method is a numerical algorithm used to find the root of a function within a specified interval. It relies on the concept of repeatedly dividing the interval in half and narrowing down the search space until the root is found or a desired level of accuracy is achieved.
Here's how the bisection method works:
1.	Begin with an interval [a, b] where the function changes sign (i.e., f(a) * f(b) < 0), indicating the presence of a root between a and b.
2.	Compute the midpoint c of the interval: c = (a + b) / 2.
3.	Evaluate the function at the midpoint: f(c).
4.	Determine the new interval based on the sign of f(c):
•	If f(c) = 0, c is the root.
•	If f(a) * f(c) < 0, the root lies between a and c, so set b = c.
•	If f(b) * f(c) < 0, the root lies between b and c, so set a = c.
5.	Repeat steps 2-4 until the desired accuracy is achieved or a predetermined number of iterations is reached. The interval becomes smaller with each iteration, narrowing down the range where the root is located.
The bisection method is guaranteed to converge to a root as long as the initial interval contains a root and the function is continuous. However, it may converge slowly, especially for functions with complex behavior or multiple roots.
Overall, the bisection method is a straightforward and reliable technique for finding roots of equations, but it can be computationally expensive compared to more advanced algorithms like Newton's method or the secant method.
![Picture1](https://github.com/IslamEssamSamir/NumaricalAnalysis/assets/104682652/8f34b15d-a4e8-4a61-a8af-65ddf951e343)



 


### False Position Method

The false position method, also known as the regula falsi method, is a numerical algorithm used to approximate the root of a function within a specified interval. It is similar to the bisection method but takes into account the function values at the endpoints of the interval to provide a more accurate estimate.
Here's how the false position method works:
1.	Begin with an interval [a, b] where the function changes sign (i.e., f(a) * f(b) < 0), indicating the presence of a root between a and b.
2.	Compute the x-coordinate of the point where the line connecting the endpoints (a, f(a)) and (b, f(b)) intersects the x-axis. This point is given by the formula: c = (a * f(b) - b * f(a)) / (f(b) - f(a))
3.	Evaluate the function at the midpoint c: f(c).
4.	Determine the new interval based on the sign of f(c):
•	If f(c) = 0, c is the root.
•	If f(a) * f(c) < 0, the root lies between a and c, so set b = c.
•	If f(b) * f(c) < 0, the root lies between b and c, so set a = c.
5.	Repeat steps 2-4 until the desired accuracy is achieved or a predetermined number of iterations is reached. The interval becomes smaller with each iteration, narrowing down the range where the root is located.
The false position method converges to a root faster than the bisection method because it uses linear interpolation instead of halving the interval at each step. This makes it more efficient for finding roots, especially when the function is approximately linear in the vicinity of the root.
However, it's important to note that the false position method may encounter convergence issues in some cases, such as when the function has flat regions or multiple roots close together. These situations can lead to slow convergence or even divergence of the method.
In summary, the false position method is a variation of the bisection method that incorporates linear interpolation to approximate the root of a function within an interval. It can provide faster convergence for certain types of functions but may encounter limitations in certain scenarios.

![Picture2](https://github.com/IslamEssamSamir/NumaricalAnalysis/assets/104682652/288eb050-d4eb-4e31-bb30-c1fa201710f6)



 


### Simple Fixed Point Method

Apologies for the confusion in my previous response. The "simple fixed-point method" you referred to is a different term for the method known as the "fixed-point iteration method."
In the fixed-point iteration method, the goal is to find the fixed point of a function, which is a value where the function's output is equal to its input, i.e., f(x) = x. This method involves iteratively applying a function transformation to an initial guess to converge to the fixed point.
Here's a step-by-step explanation of the simple fixed-point method:
1.	Start with an initial guess for the fixed point, denoted as x₀.
2.	Define a function g(x) that is derived from the original equation f(x) = x. Rearrange the equation to the form x = g(x), making x the dependent variable on one side.
3.	Apply the function transformation g(x) to the current approximation: x₁ = g(x₀).
4.	Repeat step 3 using the previous approximation as the input: x₂ = g(x₁), x₃ = g(x₂), and so on.
5.	Continue iterating until the sequence {x₀, x₁, x₂, ...} converges to a fixed point. This can be determined by checking if the difference between consecutive approximations falls below a desired tolerance level or by reaching a specified number of iterations.
The choice of the function g(x) is crucial for the convergence of the fixed-point iteration method. To ensure convergence, g(x) should satisfy certain conditions, such as being continuous on an interval containing the fixed point and having a derivative with an absolute value less than 1 in that interval (i.e., |g'(x)| < 1). These conditions ensure that the sequence of approximations converges to the fixed point.
It's important to note that the fixed-point iteration method may not always converge or may converge to a different fixed point if the conditions for convergence are not met. Additionally, the method can be sensitive to the choice of initial guess.
Overall, the simple fixed-point method is an iterative technique used to find the fixed point of a function. It provides a basic approach for solving fixed-point problems and serves as the foundation for more advanced algorithms in numerical analysis.

 ![Picture3](https://github.com/IslamEssamSamir/NumaricalAnalysis/assets/104682652/6d621629-78ed-49aa-a759-57a8c4a34f20)



### Newton Method
The Newton's method, also known as Newton-Raphson method, is a numerical algorithm used to approximate the roots of a differentiable function. It provides a way to iteratively refine an initial guess to converge to a more accurate solution.
Here's how the Newton's method works:
1.	Start with an initial guess x₀ for the root of the function.
2.	Compute the value of the function at the initial guess: f(x₀).
3.	Compute the derivative of the function at the current guess: f'(x₀).
4.	Use the current guess and the derivative to compute the next approximation using the formula: x₁ = x₀ - (f(x₀) / f'(x₀))
5.	Repeat steps 2-4 until the desired accuracy is achieved or a predetermined number of iterations is reached.
The Newton's method takes advantage of the tangent line approximation to the function at each iteration. The formula for the next approximation (step 4) comes from setting the tangent line to the function equal to zero and solving for x. The process is repeated, refining the approximation by iteratively updating the guess based on the slope of the function.
The convergence of Newton's method is typically fast when the initial guess is close to the root and the function is well-behaved. However, it may fail or converge slowly in certain cases, such as when the initial guess is far from the root, when the function has multiple roots, or when encountering a point where the derivative is close to zero (i.e., near a horizontal tangent or an inflection point).
To improve the convergence or handle cases where Newton's method fails, variations like the modified Newton's method or hybrid methods can be employed.
In summary, the Newton's method is an iterative technique for finding the roots of a function by utilizing function evaluations and its derivatives. It provides a fast convergence for well-behaved functions but can encounter limitations or convergence issues in certain scenarios.

 ![Picture4](https://github.com/IslamEssamSamir/NumaricalAnalysis/assets/104682652/3c9c385e-45a6-4001-98f8-d2b614c16884)




### Secant Method

The secant method is a numerical algorithm used to approximate the roots of a function. It is an iterative method that does not require knowledge of the derivative of the function, making it a useful alternative when the derivative is difficult to compute or unavailable.
Here's how the secant method works:
1.	Start with two initial guesses, x₀ and x₁, for the root of the function.
2.	Evaluate the function at the initial guesses: f(x₀) and f(x₁).
3.	Compute the next approximation using the secant formula: x₂ = x₁ - (f(x₁) * (x₁ - x₀)) / (f(x₁) - f(x₀))
4.	Update the values of x₀ and x₁ by shifting them to the right: x₀ = x₁ x₁ = x₂
5.	Repeat steps 2-4 until the desired accuracy is achieved or a predetermined number of iterations is reached.
The secant method approximates the root of the function by fitting a secant line through two points on the graph of the function and finding the x-intercept of that line. The formula in step 3 is derived from the equation of a secant line and solves for the x-coordinate where the secant line crosses the x-axis.
The secant method typically converges slower than the Newton's method but is more versatile since it does not require the computation of derivatives. It can be useful when the derivative is either difficult to obtain or computationally expensive. However, like other iterative root-finding methods, the secant method may encounter convergence issues or fail to converge if the function has multiple roots or exhibits certain behaviors like flat regions or oscillations.
To improve convergence or handle specific cases, variations of the secant method, such as the inverse quadratic interpolation, can be employed.
In summary, the secant method is an iterative numerical algorithm for approximating the roots of a function without explicitly requiring the derivative. It provides an alternative to the Newton's method, although with slower convergence, and can be effective when the derivative is unavailable or challenging to compute.


 ![Picture5](https://github.com/IslamEssamSamir/NumaricalAnalysis/assets/104682652/cc7b4fd3-3f51-473a-8811-6b47745cb616)





## Chapter 2

### Gauss Elimination
Gauss elimination, also known as Gaussian elimination, is a widely used method in linear algebra for solving systems of linear equations. It aims to transform a system of equations into an equivalent, simpler system that can be easily solved.
Here's how the Gauss elimination method works:
1.	Write the system of linear equations in matrix form. For example, if we have n equations with n variables, the system can be represented as Ax = b, where A is an n x n coefficient matrix, x is a column vector of the variables, and b is a column vector of constants on the right-hand side.
2.	Augment the coefficient matrix A with the column vector b to form an augmented matrix [A | b].
3.	Perform row operations on the augmented matrix to eliminate the variables below the main diagonal. The main goal is to transform the augmented matrix into an upper triangular form.
4.	Start with the first row and eliminate the coefficients below the first column by subtracting multiples of the first row from the subsequent rows. The aim is to create zeros below the main diagonal in the first column.
5.	Move to the second row and eliminate the coefficients below the second column using similar row operations.
6.	Repeat this process for the remaining rows and columns until the augmented matrix is in upper triangular form, with zeros below the main diagonal.
7.	Solve the simplified system of equations by back substitution. Start with the last equation, which should only have one variable. Solve for that variable and substitute its value back into the second-to-last equation. Continue this process until all variables are determined.
8.	The resulting values of the variables constitute the solution to the original system of linear equations.
Gauss elimination is an efficient method for solving systems of linear equations and has applications in various fields such as engineering, physics, and computer science. It simplifies the system by reducing it to an upper triangular form, making it easier to solve. However, it's important to note that the method may encounter challenges if the coefficient matrix is singular or ill-conditioned. In such cases, additional techniques like pivoting can be employed to enhance the accuracy and stability of the solution.
 
![Picture6](https://github.com/IslamEssamSamir/NumaricalAnalysis/assets/104682652/ca989122-f423-4b1f-996f-c8a643697eee)

 
![Picture7](https://github.com/IslamEssamSamir/NumaricalAnalysis/assets/104682652/1bb7d6f1-a89e-45ea-9ac7-487f4a62d1ae)



### LU Decomposition Method
LU decomposition, also known as LU factorization, is a numerical method used to decompose a square matrix into the product of two matrices: a lower triangular matrix (L) and an upper triangular matrix (U). This decomposition is useful in solving systems of linear equations and in matrix inversion.
Here's how the LU decomposition method works:
1.	Start with a square matrix A of size n x n, which represents the coefficients of a system of linear equations or any other square matrix that needs to be decomposed.
2.	Decompose the matrix A into the product of two matrices, L and U, such that A = LU.
3.	The lower triangular matrix L is created by setting the main diagonal elements of L to 1 and computing the remaining elements by performing row operations on A to eliminate the coefficients below the main diagonal. The goal is to transform A into an upper triangular form.
4.	The upper triangular matrix U is obtained as a result of the row operations performed on A in step 3.
5.	The resulting matrices L and U provide a factorization of the original matrix A.
6.	To solve a system of linear equations, Ax = b, using LU decomposition, follow these steps: a. Decompose matrix A into L and U using the steps outlined above. b. Solve Ly = b for y by forward substitution, where y is a column vector. c. Solve Ux = y for x by back substitution, where x is the solution vector.
7.	The resulting vector x will be the solution to the original system of linear equations.
LU decomposition is advantageous for solving multiple systems of linear equations with the same coefficient matrix. Once the LU decomposition is obtained, solving systems of equations for different right-hand side vectors can be done efficiently using the forward and back substitution steps mentioned in step 6.
Furthermore, LU decomposition can be utilized for matrix inversion. If A is invertible, the inverse of A can be found by solving the equation AX = I, where I is the identity matrix, using LU decomposition.
The LU decomposition method provides a versatile and efficient approach for solving linear systems and performing matrix operations. It avoids the need to repeatedly perform costly row operations, making it a valuable tool in numerical computations and applications.



### Cramer’s Rule
Cramer's rule is a method used to solve systems of linear equations by expressing the solution in terms of determinants. It provides a formulaic approach to find the values of the variables in a system of equations without the need for matrix inversion.
Here's how Cramer's rule works for a system of linear equations:
1.	Consider a system of linear equations with n variables: a₁₁x₁ + a₁₂x₂ + ... + a₁ₙxₙ = b₁ a₂₁x₁ + a₂₂x₂ + ... + a₂ₙxₙ = b₂ ... aₙ₁x₁ + aₙ₂x₂ + ... + aₙₙxₙ = bₙ
2.	Form the coefficient matrix A by placing the coefficients of the variables in each equation in an n x n matrix: A = [a₁₁ a₁₂ ... a₁ₙ] [a₂₁ a₂₂ ... a₂ₙ] [... ... ...] [aₙ₁ aₙ₂ ... aₙₙ]
3.	Compute the determinant of the coefficient matrix A, denoted as det(A).
4.	For each variable xᵢ in the system, create a new matrix B by replacing the i-th column of A with the column vector b: Bᵢ = [a₁₁ a₁₂ ... aᵢ₋₁ b₁ aᵢ₊₁ ... a₁ₙ] [a₂₁ a₂₂ ... aᵢ₋₁ b₂ aᵢ₊₁ ... a₂ₙ] [... ... ... ...] [aₙ₁ aₙ₂ ... aᵢ₋₁ bₙ aᵢ₊₁ ... aₙₙ]
5.	Compute the determinant of each matrix Bᵢ, denoted as det(Bᵢ).
6.	The solution for each variable xᵢ is given by the ratio of the determinant of Bᵢ to the determinant of A: xᵢ = det(Bᵢ) / det(A)
Cramer's rule provides a way to solve systems of linear equations by computing determinants. However, it can be computationally expensive, especially for larger systems, as it involves computing multiple determinants. Additionally, Cramer's rule is only applicable when the coefficient matrix A is non-singular (i.e., has a non-zero determinant), and the system has a unique solution.
In summary, Cramer's rule is a method used to find the solution to a system of linear equations by expressing the values of the variables in terms of determinants. It provides an alternative approach to solving systems of equations without the need for matrix inversion.


![Picture8](https://github.com/IslamEssamSamir/NumaricalAnalysis/assets/104682652/aafda4bd-2dbe-4e7e-8e6a-826a50fc585f)

![Picture9](https://github.com/IslamEssamSamir/NumaricalAnalysis/assets/104682652/b198847b-bae0-415a-928b-6b5322802dd5)


 


 
