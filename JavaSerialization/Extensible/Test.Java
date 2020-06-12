import java.io.*;

public class Test 
{
    public static void main(String args[]) throws IOException, ClassNotFoundException 
    {
        Country c  = new Country();
        c.code = 11;
        c.name = "ABC";



        //Serializing 

        FileOutputStream fileout = new FileOutputStream("serial.txt");
        ObjectOutputStream objectout = new ObjectOutputStream(fileout);
        c.writeExternal(objectout);
        objectout.close();
        fileout.close();


        //Deserializing

        FileInputStream filein = new FileInputStream("serial.txt");
        ObjectInputStream objectin = new ObjectInputStream(filein);

        Country C_ = new Country();
        C_.readExternal(objectin);
        objectin.close();
        filein.close();



        System.out.println("Country code = ");
        System.out.println(C_.code);
        System.out.println("Country name = ");
        System.out.println(C_.name);


    }

    
}