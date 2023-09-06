module default {

type user{
   required name: str;
   required email: str;
   required phone_number: str;
   required resturant_name: restaurant;
   required password: str;
   #should the password be removed ?? where shall it be ?
   required role: str; #owner or contributor

}
type restaurant {
 
  required email: str;
  required restaurant: str;
  required phone_number:str;
  facebook: str;
  instagram: str;
  twitter: str;
  required password: str;
  required country:str;
  required address:str;
  city: str;
  district: str;
  tags: array<str>;
  opening_hours: str;
  menu_pdf: str;
  menu_upload_date:datetime ;
  cover_photo: str;
  main_photo: str;
  rating : int16;
 
}

  }