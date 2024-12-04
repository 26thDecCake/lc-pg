import java.util.HashMap;

public class Main {

  public static void main(String[] args) {
    HashMap<Integer, String> countries = new HashMap<Integer, String>();

    countries.put(1, "Indonesia");
    countries.put(2, "Malaysia");
    countries.put(3, "Thailand");
    countries.put(4, "Singapore");

    System.out.println(countries);

    System.out.println("hashmap contains " + countries.size() + " countries");

    System.out.println("country with key 1 is " + countries.get(1));

    countries.remove(3);

    countries.replace(4, "Singapore", "Cambodia");

    System.out.println(countries);

    if (countries.containsKey(2)) {
      System.out.println("hashmap contains country with key 2. The country name is " + countries.get(2));
    }

    for (Integer key : countries.keySet()) {
      System.out.println("country with key " + key + " is " + countries.get(key));
    }

    // countries.clear();
    // System.out.println(countries);

    String name = "Bro";
    myinterface obj = (val) -> {
      System.out.println("hello world");
      System.out.println("Nice day right " + val);
    };

    myinterface obj2 = (val) -> {
      System.out.println("hello " + val);
    };

    obj.message(name);
    obj2.message(name);

    myframe fMyframe = new myframe();
  }
}