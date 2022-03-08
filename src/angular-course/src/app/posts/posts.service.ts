import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Subject } from "rxjs";
import { Post } from "./interfaces/post.model";
@Injectable({providedIn: "root"})
export class PostsService{
  private posts: Post[] = [];
  private postsUpdated = new Subject<Post[]>();

  constructor(private httpClient: HttpClient) {}

  getPosts() {
    this.httpClient.get<Post[]>('https://localhost:7100/api/posts')
    .subscribe((postData)=> {
      this.posts = postData;
      this.postsUpdated.next([...this.posts]);
    });
  }

  getPostUpdatedListener(){
    return this.postsUpdated.asObservable();
  }

  addPost(title: string, content: string){
    const post: Post = { id: '', title: title, content: content };

    this.httpClient.post('https://localhost:7100/api/posts', post)
    .subscribe(()=>{
      this.posts.push(post)
      this.postsUpdated.next([...this.posts])
    });
  }

}
