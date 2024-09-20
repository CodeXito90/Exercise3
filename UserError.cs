using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    public abstract class UserError
    {
        public abstract string UEMessage();

        public class NumericInputError : UserError 
        {
            public override string UEMessage()
            {
                return("You tried to use a numeric input in a text only field. This fired an error!");
            }            
        }

        public class TextInputError : UserError 
        {
            public override string UEMessage()
            {
                return("You tried to use a text input in a numeric only field. This fired an error!");
            }
        }

        public class NullError : UserError 
        {
            public override string UEMessage() 
            {
                return ("It cannot be null here bro! try again next time");
            }
        }

        public class EmptyFieldError : UserError 
        {
            public override string UEMessage()
            {
                return ("You mleft the field empty! This fired an error smartass");
            }
        }
    }
  
}
