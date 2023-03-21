package dto;

import java.util.Date;

public class Book {

	public String Name;
	private String authorName;
	private String publisher;
	private int edition;
	private int quantity;
	private boolean isExchanged;
	private Date year;
	private String language;
	
	public String getName() {
		return Name;
	}
	public String getAuthorName() {
		return authorName;
	}
	public String getPublisher() {
		return publisher;
	}
	public int getEdition() {
		return edition;
	}
	public int getQuantity() {
		return quantity;
	}
	public void setQuantity(int quantity) {
		this.quantity = quantity;
	}
	public boolean isExchanged() {
		return isExchanged;
	}
	public void setExchanged(boolean isExchanged) {
		this.isExchanged = isExchanged;
	}
	public Date getYear() {
		return year;
	}
	public String getLanguage() {
		return language;
	}
	
	
	
}
