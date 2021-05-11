using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;  
    private Vector3 moveVector;
    private float speed = 5.0f; 
    private float verticalVelocity =0.0f;
    private float gravity =11.0f;
    private float animationDuration  =2.0f;

    Transform parentCube;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time < animationDuration )
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return; //fix camera angle 
        }
        moveVector = Vector3.zero;

        if(controller.isGrounded) // gravity settings
        {
            verticalVelocity =-0.5f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        moveVector.x = Input.GetAxisRaw("Horizontal") *speed; // X
        moveVector.y = verticalVelocity;//Y
        moveVector.z = speed;//Z


        controller.Move(moveVector * Time.deltaTime); 
    }

    
}





//Solid Prensipleri
/*
1- Single Responsibility Principle
 “Tek Sorumluluk” anlamına gelen bu prensipte amaç; geliştirilen projede bir güncelleme veya değişiklik yapılması istendiğinde kodların içinde kaybolmadan,
  yalnızca ilgili metoda giderek istenilen değişikliğin yapılmasının sağlanmasıdır.
  2- Open/Closed Principle
 “Açık/Kapalı” olan prensip, projede geliştirilen nesnelerin geliştirilmeye açık ama değişime kapalı olmaları gerektiğini ifade eder.
  Yani bir nesne davranışını değiştirmeden yeni özellikler kazabiliyor olmalıdır. Bu prensip, sürdürülebilir ve tekrar kullanılabilir yapıda kod yazmanın temelini oluşturur.
  3- Liskov Substitution Principle
“Yerine Geçme” olarak çevirdiğimiz prensibe göre; miras alarak türemiş olan class’ların önce miras aldıkları nesnenin tüm özelliklerini kullanması,
 daha sonra da kendi özelliklerini barındırması gerekir. Eğer oluşturduğumuz class, miras aldığı nesnenin ‘tüm’ özelliklerini kullanmayacaksa ortaya gereksiz kod blokları
  çıkar ve bu da bir geliştiricinin isteyeceği en son şeydir. Çünkü bir geliştirici her daim ‘Clean Code’ yazmaya çalışır.
  4- Interface Segregation Principle
“Arayüz Ayırımı” prensibinde; bir interface’e gerekenden fazla sorumluluk eklemek yerine, daha özelleştirilmiş birden fazla interface oluşturulmalıdır. 
Nesneler, ihtiyacı olmayan özellik veya metotlar içeren interface’leri miras almaya zorlanmamalıdır. 
5- Dependency Inversion Principle
“Bağımlılığın Ters Çevrilmesi” olan bu prensibe göre; alt sınıflarda yapılan değişiklikler üst sınıfları etkilememelidir yani sınıflar arası bağımlılıklar olabildiğince
 az olmalıdır ve özellikle üst seviye sınıflar, alt seviye sınıflara bağımlı olmamalıdır. Burada yüksek seviye sınıf ile düşük seviye sınıf arasında bir soyutlama
  katmanı oluşturarak her iki sınıfı da soyut kavramlar üzerinden yönetmeliyiz.





*/