package model;

public abstract class Book {
	protected String name;
	protected long serialNumber;
        protected Person myOwner;
        
        Book(String name){
            this.name = name;
        }
	
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public long getSerialNumber() {
		return serialNumber;
	}
	public void setSerialNumber(long serialNumber) {
		this.serialNumber = serialNumber;
	}
	
}