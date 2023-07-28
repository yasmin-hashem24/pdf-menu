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
  required name: str;
  required email: str;
  required phone_number:str;
  facebook_link: str;
  instagram_link: str;
  required password: str;
  required district: str;
  tags: array<str>;
  opening_hours: str;
  menu_pdf: str;
  menu_upload_date: datetime;
  cover_photo: str;
  rating : int16;
 
}

type restaurant_filter {
    name: restaurant;
    district: str;
    location: str;
    tags: array<str>;
  }

  
type top_rated {
    name: restaurant;

  }}