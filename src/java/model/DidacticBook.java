package model;

import java.util.Iterator;
import java.util.Vector;

public final class DidacticBook extends Book implements SerialNumber{

    public DidacticBook(String name) {
        super(name);
    }
    
    
    
    public long GenerateSerialNumber(Vector<Book> library){
        long serialNumber = 70000;
        Iterator itr = library.iterator();
        while(itr.hasNext()){
            itr.next();
            serialNumber++;
        }
        return serialNumber;
    }
}