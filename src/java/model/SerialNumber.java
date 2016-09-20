package model;

import java.util.Vector;

public interface SerialNumber {
	public abstract long GenerateSerialNumber(Vector<Book> library); 
}