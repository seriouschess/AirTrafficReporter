namespace MainApp.BusinessLogic
{
    //Validates user input
    public class Validator
    {
        public Validator(){ }

        //returns valid if true
        public string ValidateString(string bogie){ 
            if(bogie == null){
                return "String cannot be null";
            }else if(bogie.Length < 3){
                return "String cannot be less than than 3 characters.";
            }else if(bogie.Length > 25){
                return "String cannot be greater than 25 characters.";
            }
            return "valid";
        }
    }
}