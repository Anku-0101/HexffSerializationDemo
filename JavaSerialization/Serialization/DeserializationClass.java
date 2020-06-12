import java.io.*;

public class DeserializationClass
{
    public static void main(String[] args) throws IOException, ClassNotFoundException

    {
        Emp emp_ = null;

        try
        {
            FileInputStream fileIn = new FileInputStream("serial.txt");
            ObjectInputStream in = new ObjectInputStream(fileIn);

            emp_ = (Emp)in.readObject();
            
            in.close();
            fileIn.close();
        }

        finally
        {
            System.out.println("Deserializing Employee ... ");
            System.out.println("First Name : " + emp_.Name);
            System.out.println("Employee age : " + emp_.Age);
        }
    }
}