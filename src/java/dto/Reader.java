package dto;

public class Reader {

	private long hashId;
	private String Email;
	private int credit;
	
	Book book = new Book();

	public String getEmail() {
		return Email;
	}

	public void setEmail(String Email) {
		this.Email = Email;
	}

	public int getDonated() {
		return donated;
	}

	public void setDonated(int donated) {
		this.donated = donated;
	}

	public void donate(Book book) {
		
	}
	public void exchangeBooks(Book book1,Book book2) {
		
	}
	
}
