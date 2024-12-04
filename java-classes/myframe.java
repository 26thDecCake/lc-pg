import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JButton;
import javax.swing.JFrame;

public class myframe extends JFrame {
  JButton myButton = new JButton("My Button");
  JButton myButton2 = new JButton("Second Button");

  myframe() {

    this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
    this.setSize(700, 700);
    this.setVisible(true);
    this.setLayout(null);

    myButton.setBounds(100, 100, 200, 100);
    myButton.addActionListener(
        (e) -> System.out.println("Button Clicked"));

    myButton2.setBounds(300, 300, 200, 100);
    myButton2.addActionListener(
        (e) -> System.out.println("Second Button"));

    this.add(myButton);
    this.add(myButton2);

  }
}
