# git-training

Once you clone the repository, please open terminal in the root folder and run following command:
`dotnet script .hooks\repo-init.csx`

In this repo, you'll find amazing dutch fairytale called The Boy Who Wanted More Cheese. However, you'll notice that some sentences are missing! Those sentences are in separate files called Sentence_<sentence_number> where number corresponds to the number of missing sentence in the story.

But wait! If you read the sentences, you'll notice that there's something fishy about them... Better check out if everything aligns with the original story. You can find the link to it in file tale_url.txt
It seems that some of them will require hotfix!

## Task 1:
1. Create hotfix branch from the acceptance branch
2. Update your sentences with the correct one
3. Commit the changes and push them to the remote repository
4. Create pull request targeting acceptance, pick a reviewer 
5. Once the reviewer accepts your pull request, merge it
6. Wait until the result comment from merge or pr action
7. If pull request for merging to develop is created, resolve conflicts, add reviewer and merge when it's accepted!
8. ???
9. Profit!

Ok, now all bugz seems to be gone! Time add missing sentences ("features") to the story

## Task 2:
1. Create feature branch from the development branch
2. Paste your sentences to correct places in the story
3. Commit the changes and push them to the remote repository
4. Create pull request targeting development, pick a reviewer 
5. Once the reviewer accepts your pull request, merge it

That's it, you made the story complete! :)
