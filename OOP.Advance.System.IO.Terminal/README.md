## :pushpin: System IO :pushpin:


<img class="irc_mi" src="https://user-images.githubusercontent.com/38188753/50302490-b0913f00-04a3-11e9-8543-a0b3dff929d6.jpg" width="551" height="550" onload="typeof google==='object'&amp;&amp;google.aft&amp;&amp;google.aft(this)"  style="margin-top: 91px;" alt="Bank and client">

# :bank:
## UniversalTerminal
```C#
        static class UniversalTerminal
    {
        private static decimal TotalMoney=500000000;
        private static FileStream file= File.Open("TerminalAmount.text", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);
        private static StreamWriter writer= new StreamWriter(file);
     
    
        static UniversalTerminal()
        {
           // Console.WriteLine("Enter Pin Code");       
            writer.WriteLine($"{TotalMoney.ToString()} {DateTime.Now}");        
        }

        public static void Put(decimal sum)
        {
            TotalMoney += sum;
            using (writer)
            {
                writer.WriteLine($"{TotalMoney.ToString()} {DateTime.Now}");
                          
            }                    
        }

        public static void WithDram(decimal sum)
        {
            TotalMoney -= sum;          
        }
    }
```
# :boy::man::older_man::family:
## User
```C#
  class User
    {
        public string FistName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public decimal Money { get; set; }
      
    }    
```


