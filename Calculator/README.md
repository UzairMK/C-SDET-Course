# Int32 Calculator

## Calculator Aims

- [x] Takes two int32 values, performs a mathematical operation on them and returns the result as int32.

- [x] Should have the operations add, subtract, multiply, divide and modulo.

- [x] Throw an error if any of the values exceed the range of int32.

- [x] Throw an error when dividing by 0.

- [x] Display calculation history.

- [x] Bonus: Export calculation history to text file.

  

## Calculator App

​	Windows Presentation Foundation (WPF) was used to create the graphical user interface (GUI) for the app. The app was kept simple, only using buttons, text boxes, labels and a scroll viewer. The image below shows the final product.

![Basic](Images\Basic.png)

​	To use the calculator, simply type in a number within int32's range into both the yellow text boxes and between the two text boxes are five operator buttons, which when clicked will perform that operation on the two numbers provided, taking the top number as the first parameter and the bottom number as the second parameter. The result of calculations appears in the green label. 

​	One can click the green "^" button to clear the yellow input text boxes and insert the result value into the top text box. This was implemented to make it easier to chain calculations and the button only works when the value inside the result box is a valid input.

​	On the left there is a history column which shows your previous calculations so one does not need to note down results separately when working a large calculations. The clear history button will clear the whole history and the button next to the history text is used to toggle between "Spread" mode and "Compact" mode. "Spread" mode is displayed in the image and it puts a empty line between each calculation where as "Compact" mode removes those empty lines. "Spread" mode is clearer but "Compact" mode lets the user see more calculations in one go. This button allows the user to use what they would prefer. There is also an export button on the right of the history text if one wants a text file filled with the calculations they performed (example below). This text file will appear in the same directory as the the .exe file and if it already exists, the new history items will be appended to the end of the file. 

![ExportHistoryExample](Images\ExportHistoryExample.png)



## Handling Invalid Inputs

​	The inputs in both text boxes have to be within int32 range. If something else is put there instead, the green result box will display "Invalid Input" as seen below. This will happen if either input box is empty, has characters in it or the number is outside int32 range.

![Invalid_Input](Images\Invalid_Input.png)



## Handling Output Errors

​	To make things different, instead of handling output errors like input errors, message boxes were used as shown below. The output errors that needed to be handled were when the result was outside int32 range and when division by zero was occurring.

![Output_Errors](Images\Output_Errors.png)



## Calculator Library Class

​	A calculator class was created in the CalculatorLib namespace, using test driven development, to store static methods for all the required operations. For all the methods, the ternary if else statement was used to reduce the amount of typing though it might make the code harder to understand for some people.

##### Add

```csharp
public static int Add(int a, int b)
    => b > int.MaxValue - a ? throw new Exception("Result above max value") 
    : b < int.MinValue + a ? throw new Exception("Result below min value") : a + b;
```

​	Before addition is done, the code checks to make sure the resulting value will be in int32's range and this was done without casting any variables. If the resulting value will be above the max value or below the min value, an exemption will be thrown, else the operation will be performed.

##### Subtract

```csharp
public static int Subtract(int a, int b) 
    => a <  int.MinValue + b ? throw new Exception("Result below min value") 
    : -b > int.MaxValue - a ? throw new Exception("Result above max value") : a - b;
```

​	Before subtraction is done, the code checks to make sure the resulting value will be in int32's range and this was done without casting any variables. If the resulting value will be above the max value or below the min value, an exemption will be thrown, else the operation will be performed.

##### Multiply

```csharp
public static int Multiply(int a, int b) 
    => (long)a * b > int.MaxValue ? throw new Exception("Result above max value") 
    : (long)a * b < int.MinValue ? throw new Exception("Result below min value") : a * b;
```

​	Before multiplication is done, the code checks to make sure the resulting value will be in int32's range and unfortunately I could not do this without casting the variable a to a int64. If the resulting value will be above the max value or below the min value, an exemption will be thrown, else the operation will be performed.

##### Divide

```csharp
public static int Divide(int a, int b) 
    => b != 0 ? a / b : throw new Exception("You can not divide by 0");
```

​	Before division is done, the code checks to make sure division by zero is not occurring. If division by zero is occurring an exemption is thrown, else the operation will be performed. Since the method returns an int32 value, division would not return any digits beyond the decimal point.

##### Modulo

```csharp
public static int Modulo(int a, int b) 
    => b != 0 ? a % b : throw new Exception("You can not divide by 0");
```

​	Before modulo is done, the code checks to make sure division by zero is not occurring. If division by zero is occurring an exemption is thrown, else the operation will be performed. 



## Behind Code

##### Global variables

​	The following variables were the global variables used.

```csharp
private static int _num1 = 0;
private static int _num2 = 0;
private static string _operator = "";
private static string _history = "";
private Queue<string> _historyQueue = new Queue<string>();
private bool _compactHistoryEnabled = false;
```

​	`_num1` and `_num2` store the two input values the calculation is going to be performed on, `_operator` is set to the operation that is going to be performed, `_history` is the string that is displayed on the left hand side of the app, `_historyQueue` is where all the history items are stored, and `_compactHistoryEnabled` determines which history mode one is on.



##### Operator button method

​	To keep the code DRY, all five operation buttons used the same method and the content of the button decided which operation was going to be performed. The method first checks to make sure the input values are valid then enters a try catch block to catch any output errors while doing the calculation. At the end of the calculation, the calculation is added to the `_historyQueue` and the `_history` is updated with `AddToHistory()` method then `_history` is displayed on the scroll viewer.

```csharp
		private void Equals(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            _operator = button.Content.ToString();
            bool num1Bool = int.TryParse(TextBoxNum1.Text, out _num1);
            bool num2Bool = int.TryParse(TextBoxNum2.Text, out _num2);

            if (!num1Bool || !num2Bool)
            {
                LabelResult.Content = "Invalid Input";
                return;
            }

            try
            {
                switch (_operator)
                {
                    case "+":
                        LabelResult.Content = Calculator.Add(_num1, _num2);
                        break;
                    case "-":
                        LabelResult.Content = Calculator.Subtract(_num1, _num2);
                        break;
                    case "x":
                        LabelResult.Content = Calculator.Multiply(_num1, _num2);
                        break;
                    case "/":
                        LabelResult.Content = Calculator.Divide(_num1, _num2);
                        break;
                    case "%":
                        LabelResult.Content = Calculator.Modulo(_num1, _num2);
                        break;
                    default:
                        break;
                }

                string historyItem = $"{_num1} {_operator} {_num2}\n= {LabelResult.Content}\n";
                _historyQueue.Enqueue(historyItem);
                AddToHistory(historyItem);
                ScrollViewerHistory.Content = _history;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Calculator Error");
            }
        }
```



##### Add to history method

​	Every time the history is updated, the new history item is concatenated to the front of the `_history` variable and if the history mode is "Spread", an empty line is also added in between.

```csharp
        private void AddToHistory(string historyItem)
        {
            if (_compactHistoryEnabled)
                _history = historyItem + _history;
            else
                _history = historyItem + "\n" + _history;
        }
```



##### Clear history button method

​	The `ButtonClearHistory_Click` method is attached to the "Clear History" button and it wipes the displayed history as well as clears the `_historyQueue`.

```csharp
        private void ButtonClearHistory_Click(object sender, RoutedEventArgs e)
        {
            _history = "";
            TextBlockHistory.Text = _history;
            _historyQueue.Clear();
        }
```



##### History mode button

​	The `ButtonCompactHistory_Click` method is attached to the "History Mode" button (appears as S or C in the app) and it toggles between the 2 modes and makes sure the history is updated at the end of the method so that its effect appears straight away.

```csharp
        private void ButtonCompactHistory_Click(object sender, RoutedEventArgs e)
        {
            if (_compactHistoryEnabled)
            {
                ButtonCompactHistory.Content = "S";
                _compactHistoryEnabled = false;
            }
            else
            {
                ButtonCompactHistory.Content = "C";
                _compactHistoryEnabled = true;
            }

            RemakeHistory();
        }
```



##### Remake history method

​	The `RemakeHistory` method does as the name suggests. It recreates the `_history` variable using all the history items in `_historyQueue`, making sure to add empty lines in is the history mode is "Spread", then displays `_history` on the scroll viewer.

```csharp
        private void RemakeHistory()
        {
            _history = "";

            foreach (var item in _historyQueue)
            {
                AddToHistory(item);
            }

            ScrollViewerHistory.Content = _history;
        }
```



##### Export history button

​	The `ExportHistory` method is attached to the purple export button to the right of the history text. It will create a text file called "Int32CalcHistory" in the same directory as the .exe file and if a text file with the same name exists in that location, then it will append on to it. The date and time is written into the file followed by the calculation history.

```csharp
        public async void ExportHistory(object sender, RoutedEventArgs e)
        {
            using StreamWriter file = new("Int32CalcHistory.txt", append: true);
            await file.WriteLineAsync(DateTime.Now.ToString("###[dd/MM/yyyy]###[HH:mm:ss]###"));
            await file.WriteLineAsync(_history);
        }
```



##### "^" button method

​	The `ButtonResultToNum1_Click` method is attached to the "^" button and it checks if the value in the result box is a valid input and if it is, only then does it clear the boxes and transfer the result value to the top input box.

```csharp
        private void ButtonResultToNum1_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(LabelResult.Content.ToString(), out _num1))
                return;
            TextBoxNum1.Text = LabelResult.Content.ToString();
            TextBoxNum2.Text = "";
            LabelResult.Content = "";
        }
```

