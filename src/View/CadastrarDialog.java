package View;

import java.awt.FlowLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JButton;
import javax.swing.JDialog;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JTextField;
class CadastrarDialog extends JFrame
{
JDialog dialogCadastro;
public static final String[] arrayGrandesAreas = { "Literatura", "Ciências Exatas", "Generalidades", "Geografia e História" };

    public CadastrarDialog()
    {
        createAndShowGUI();
    }
    
    private void createAndShowGUI()
    {
        setTitle("SICATROLI Cadastrar");
        setDefaultCloseOperation(EXIT_ON_CLOSE);
        setLayout(new FlowLayout());

        // Must be called before creating JDialog for
        // the desired effect
        JDialog.setDefaultLookAndFeelDecorated(true);
        
        // A perfect constructor, mostly used.
        // A dialog with current frame as parent
        // a given title, and modal
        dialogCadastro=new JDialog(this,"Cadastrar Livro",true);
        
        // Set size
        dialogCadastro.setSize(600,400);
        
        // Set some layout
        dialogCadastro.setLayout(new FlowLayout());
        

        dialogCadastro.add(new JLabel("Nome do Livro"));
        dialogCadastro.add(new JTextField(20));
        
        dialogCadastro.add(new JLabel("Escolha a grande área do conhecimento clicando no botão abaixo."));
        
        JButton buttonGrandeArea = new JButton("Grande Área");
        
        buttonGrandeArea.addActionListener( new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				String stringGrandeAreas = (String) JOptionPane.showInputDialog(dialogCadastro, 
		                "Qual é a Grande Área do Conhecimento?",
		                "Grande Área do Conhecimento",
		                JOptionPane.QUESTION_MESSAGE, 
		                null, 
		                arrayGrandesAreas, 
		                arrayGrandesAreas[0]);
			}
		});
        dialogCadastro.add(buttonGrandeArea);
        
        dialogCadastro.add(new JLabel("Autor"));
        dialogCadastro.add(new JTextField(20));

        dialogCadastro.add(new JLabel("Editora"));
        dialogCadastro.add(new JTextField(20));
        
        dialogCadastro.add(new JButton("Enviar"));
        
        setSize(400,400);
        setVisible(true);
        
        // Like JFrame, JDialog isn't visible, you'll
        // have to make it visible
        // Remember to show JDialog after its parent is
        // shown so that its parent is visible
        dialogCadastro.setVisible(true);
    }
}