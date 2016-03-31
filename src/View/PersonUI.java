package View;

import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;
import javax.swing.JButton;
import java.awt.GridLayout;
import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;


public class PersonUI extends JFrame {

	private JPanel contentPane;

	/**
	 * Create the frame.
	 */
	public PersonUI() {
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 450, 300);
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(10, 5, 5, 3));
		setContentPane(contentPane);
		contentPane.setLayout(new GridLayout(1, 0, 0, 0));
		
		JButton CadastrarButton = new JButton("Cadastrar");
		CadastrarButton.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
			}
		});
		contentPane.add(CadastrarButton);
		
		JButton trocarButton = new JButton("Trocar");
		contentPane.add(trocarButton);
		
		JButton pesquisarButton = new JButton("Pesquisar");
		contentPane.add(pesquisarButton);
	}

}
