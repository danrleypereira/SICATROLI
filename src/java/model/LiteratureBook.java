package model;

import java.util.Iterator;
import java.util.Vector;

public final class LiteratureBook extends Book implements SerialNumber{

    public LiteratureBook(String name) {
        super(name);
    }
    
    
    
    public long GenerateSerialNumber(Vector<Book> library){
        long serialNumber = 10000;
        Iterator itr = library.iterator();
        while(itr.hasNext()){
            itr.next();
            serialNumber++;
        }
        return serialNumber;
    }
}