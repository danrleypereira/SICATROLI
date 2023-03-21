package dto;

public class Institution {

	private String libraryName;
	private String libraryAddress;
	private String libraryTelphone;
	
	Book book = new Book();
	
	public boolean isAvailable(Book book) {
		return true;
	}
	public void registerBook(Book book) {
		
	}
	public void findBook() {
		
	}
	
}
