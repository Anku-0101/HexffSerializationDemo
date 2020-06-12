import java.io.*;

public class Country implements Externalizable
{
    private static final long serialVersionUID = 1L;
    
    public String name;
    public int code;
    public float area;

     

    public void writeExternal(ObjectOutput out) throws IOException
    {
        out.writeUTF(name);
        out.writeInt(code);

    }


    public void readExternal(ObjectInput in) throws IOException, ClassNotFoundException
    {
        this.name = in.readUTF();
        this.code = in.readInt();
    }

}

