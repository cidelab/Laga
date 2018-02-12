<img style="float: left;" src="http://www.designemergente.org/laga/logoLarge.png">

Laga name comes from “Librería de Algoritmos Genéticos para Arquitectura”.  The concept evolved but the name remains the same. The framework is designed for easy to use. Nevertheless, you will need some programming knowledge to used efficiently and overall understand the concept of genetic algorithms. I’m open to discussing how the structure work and how could be improved. The framework currently has 3 main topics. Genetic Algorithms, Graphics, and Interoperability.

[designemergente](http://www.designemergente.org)
 
## Genetic Algorithms
This section provides all the necessary tools to design and create Genetic Algorithms. The structure is very simple to use. Call the reference <b>using Laga.GeneticAlgorithm;</b>
The structure of a generic GA works like this:
 
| step  | operation | Laga  |
| ------------- | ------------- | ------------- |
| 1 | Creates a random population | Use the class GenrChromosome.cs and or GenrPopulation.cs. But it will depend on your objective. |
| 2 | Evaluation | Is up to you, it depends on your problem. |
| 3 | select the individuals with the highest evaluation | Use the class NaturalSelection.cs |
| 4 | crossovers the selected individuals to produce inheritance | Use the class Crossover.cs |
| 5 | mutate the inheritance | Use the class Mutation.cs |
| 6 | replace the original population | Use the class Replacement.cs or develop your own method. |
| 2 | evaluate again. | Back to step 2 until stop. |

## Graphics
This section provides tools to display information related to your GA and is based in WPF, so is good to have a basic knowledge of XAML. This section grows in parallel as the GA library is developed, because is used to test the algorithm outcomes.
 
In Visual Studio, first, creates a WPF project and add Laga framework to references. Call the reference <b>using Laga.Graphics;</b>. In XAML designer add a Textbox to write on it.

| VS tool  | XAML | Laga  |
| ------------- | ------------- | ------------- |
| TextBlock | design the appearance and location | Use the class notebook to write on it. | 

## IO
This section provides a series of classes and methods to read and write Excel files. Call the reference like this <b>using Laga.IO;</b>. In order to use the Excel classes, you will need Excel installed.
 
The IO Excel provides basically two classes. Each class provides methods to open, write/read and close the excel application. 
 
| Class  | Laga  |
| ------------- | ------------- |
| IOExcelRead.cs | To read excel files. |
| IOExcelWrite.cs | To write excel files. |
