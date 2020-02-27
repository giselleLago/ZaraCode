# Zara Tech Code
##Result value: 
**36585.568**

Zara Tech Code is my first activity from Vueling University. I'am proud of myself, because i have worked with effort 
and motivation to improve my professional skills.

## Responsabilities
To solved Zara Challenge first i separate the problem in tascks, always respecting SOLID principles, where each class and 
each method will have a single responsibility, also Interface Segregation and trying to comply with the rule of 10x10x10.

## Implementation
**ExcelSource** Create a class to exctract data from a csv file.
       - Return an object list type **DailyStock**.
**DailyStock** Create a model class with 3 properties(Date, opening price, closing price).
**InvestmentSimulator** Create a class to do Math calculation.
	   - Return an object type **InvestmetResult**.
**InvestmetResult** Create a model class with 4 properties(final capital, total investment, total gain, objects list
type **Stocks**).
**Stocks** Create a model class with 3 properties(investment day, total stocks).
**ExcelExporter** Create a class to export data(date, total stocks per month, final capital, total gain,
y total investment) to a csv file.

I also create Interfaces Classes to aply Interface Segregation(I).
## Technology Stack
C# - .Net Framework - SonarLint - Git