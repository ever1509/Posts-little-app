import { Component, OnDestroy, OnInit } from "@angular/core";
import { Subscription } from "rxjs";
import { Post } from "../interfaces/post.model";
import { PostsService } from "../posts.service";

@Component({
  selector: 'app-post-list',
  templateUrl:'./posts-list.component.html',
  styleUrls: ['./posts-list.component.css']
})
export class PostListComponent implements OnInit, OnDestroy {

posts: Post[] = [];
private postsSub? : Subscription;

constructor(public postsService: PostsService) {}

ngOnInit() {
  this.postsService.getPosts();
  this.postsSub = this.postsService.getPostUpdatedListener()
  .subscribe((posts: Post[])=>
  {
      this.posts = posts;
  });
}

ngOnDestroy() {
  this.postsSub?.unsubscribe();
}

}
