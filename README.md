# Unity Project

## I. Setup Instructions

**You should only have to do this part once.**

1. Install Windows Powershell, a text editor of your choice, and Git
2. Clone the repository using either the GitHub GUI or in Powershell using `git clone https://github.com/Ellard24/UnityProject.git`.
3. Open the project folder in Unity.
4. In the Unity menu click   `Edit -> Project Settings -> Editor`
5. In the Editor menu, under `Version Control - Mode` select `Visible Meta Files`.
6. In the Editor menu, under `Asset Serialization - Mode` select `Force Text`.

**Set Up Git Config to Prevent Merge Conflicts**

1. In this repository, go into the hidden folder `.git`
2. In that folder, open the `config` file in a text editor.
3. Paste the following:
```git
[merge]
    tool = unityyamlmerge
[mergetool "unityyamlmerge"]
    trustExitCode = false
    keepTemporaries = true
    keepBackup = false
    path = 'C:\\Program Files\\Unity\\Editor\\Data\\Tools\\UnityYAMLMerge.exe'
    cmd = 'C:\\Program Files\\Unity\\Editor\\Data\\Tools\\UnityYAMLMerge.exe' merge -p "$BASE" "$REMOTE" "$LOCAL" "$MERGED"
```
4. This will instruct your repo to use the unityyamlmerge tool to try and prevet scene merge conflicts.(it doesn't always work but its worth trying to use).
5. There might be extraneous files after merging such as `.orig`. Feel free to delete them.


**Now You're set up!**

---

## II. Daily Workflow


### Here's a typical workflow for git for our team:

_Note: I'm going to demonstrate command line (CLI) commands but you can do the same things with the [GUI](https://desktop.github.com/)_

#### Before starting project work every day

1. `git checkout master` and `git pull` to get the latest updates.
2. Make sure your work is on a branch. To create a branch `git checkout -b <branch-name>`
3. Check GitHub for [any open Pull Requests]https://github.com/Ellard24/UnityProject/pulls) that other members want.

#### While working on the project
1. While you work, occasionally type `git status` to see what you've changed. If you want to view your changes per file, type `git diff <filename>`.
2. When you get to a point where you've changed stuff and made something work, `git add .` to stage all the changes in your current directory.
3. Right after staging the changes, use `git commit -m "<your-commit-message-here>"`.
4. Committing keeps track of your progress locally.

#### When you finish a project work session
1. `git pull` to get latest updates on your branch (in case someone is also working on it remotely)
2. `git push` to publish your local changes up to GitHub so everyone else can be up-to-date




