### Homework 1

For our first homework assignment we are to learn the basics of HTML and CSS. We are also required to use Bootstrap for our website we are to create. This assignment is where we are going to learn the basics of Git. We are to only use the command line while using Git. We are also going to have a working GitHub Pages repository/web page.

### Step 1: Using Git

I have never really used Git before but this assignment helped me learn the basics of Git. 

I first created a GitHub and I created my first repository on GitHub called hello-world. I can only use Git through the command line, as instructed.

I will make sure that I am in the folder where I'm going to clone my repository.

'''bash
git clone https://github.com/tapiad/hello-world.git
cd hello-world
git config --global user.name tapiad
git config --global user.email dtapia12@mail.wou.edu
''' 

Now we are going to add a README.md file and push it to the repository.

'''bash
git add README.md 
git commit -m "added README.md"
git push -u origin master
'''

If I were to edit the README.md file I will need to 'pull' first and then 'add'/'commit'/'push' again.
