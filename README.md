# Requirements
Calculator

Write an azure function to calculate a result from a set of instructions.
Instructions comprise a keyword and a number that are separated by a space per line. Instructions are loaded from file and results are output to the screen. Any number of Instructions can be specified.
Instructions should be the add, divide, multiply and subtract operators, ignoring mathematical precedence. The last instruction should be "apply" and a number (e.g., "apply 3"). The calculator is then initialised with that number and the previous instructions are applied to that number.

Two examples of the calculator lifecycle might be:

Example 1.
 [Input from file]
add 2
multiply 3
apply 3

[Output to screen]
15

[Explanation]
(3 + 2) * 3 = 15

Example 2.
 [Input from file]
multiply 9
apply 5

[Output to screen]
45

[Explanation]
5 * 9 = 45

Please include unit tests and demonstrate good architectural principles. If you test the function with postman please include an export of your tests.

# How to Run?

Clone the repo and start run.
Use postman to post a file on the endpoint - postman collection added to DevTest\postman folder.

![image](https://user-images.githubusercontent.com/37901131/121161200-a8304880-c844-11eb-9042-a7066b011269.png)

# Tests
Following unit tests are available in the unittests project
![image](https://user-images.githubusercontent.com/37901131/121204774-0a05a800-c86f-11eb-83be-7759b48a4829.png)



