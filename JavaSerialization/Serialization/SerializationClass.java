
import java.io.*;

public class SerializationClass 
{
    public static void main(String args[])
    {
        Emp emp = new Emp();
        emp.Name = "Aman";
        emp.Age = 15;

        try 
        {
            FileOutputStream fileOut = new FileOutputStream("serial.txt");
            ObjectOutputStream out = new ObjectOutputStream(fileOut);
            
            out.writeObject(emp); // Serialization
            out.close();
            fileOut.close();
            System.out.printf("Serialized data is saved in Serial.txt");
        }

        catch(IOException e)
        {
            e.printStackTrace();
        } 

    }

}