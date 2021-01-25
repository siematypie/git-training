#load "utils/command-line.csx"


var developMock = CommandLine.Execute("git branch develop"); //try to create develop branch, otherwise flow init fails
var masterMock = CommandLine.Execute("git branch master"); //try to create develop branch, otherwise flow init fails
var branchesCheckout = CommandLine.Execute("git checkout production && git checkout development && git checkout acceptance"); // to fetch all git flow branches from origin
if (branchesCheckout.IsError) {
    return branchesCheckout.ShowOutput();
}
var flowResult = CommandLine.Execute("git flow init -f -d && git config gitflow.branch.master acceptance &&  git config gitflow.branch.develop development && git config --add gitflow.multi-hotfix true", "Initializing Git Flow...");
if (developMock.IsSuccess) { // if branch was created by the script, remove it
    CommandLine.Execute("git branch -d develop");
}
if (masterMock.IsSuccess) { // if branch was created by the script, remove it
    CommandLine.Execute("git branch -d master");
}
if (flowResult.IsError) {
    return flowResult.ShowOutput();
}

Logger.LogSuccess("DONE");

Logger.LogInfo("Setting up hooks...");
var hooks = new [] {
    //standard git hooks
    "pre-commit",
    "prepare-commit-msg",
    "commit-msg",
    "post-commit",
    "post-checkout",
    "pre-rebase",

    //git flow hooks
    "post-flow-bugfix-delete",
    "post-flow-bugfix-finish",
    "post-flow-bugfix-publish",
    "post-flow-bugfix-pull",
    "post-flow-bugfix-start",
    "post-flow-bugfix-track",

    "post-flow-feature-delete",
    "post-flow-feature-finish",
    "post-flow-feature-publish",
    "post-flow-feature-pull",
    "post-flow-feature-start",
    "post-flow-feature-track",

    "post-flow-hotfix-delete",
    "post-flow-hotfix-finish",
    "post-flow-hotfix-publish",
    "post-flow-hotfix-start",
    "post-flow-hotfix-track",
    "post-flow-hotfix-pull",

    "post-flow-release-branch",
    "post-flow-release-delete",
    "post-flow-release-finish",
    "post-flow-release-publish",
    "post-flow-release-start",
    "post-flow-release-track",

    "pre-flow-bugfix-delete",
    "pre-flow-bugfix-finish",
    "pre-flow-bugfix-publish",
    "pre-flow-bugfix-pull",
    "pre-flow-bugfix-start",
    "pre-flow-bugfix-track",

    "pre-flow-feature-delete",
    "pre-flow-feature-finish",
    "pre-flow-feature-publish",
    "pre-flow-feature-pull",
    "pre-flow-feature-start",
    "pre-flow-feature-track",

    "pre-flow-hotfix-delete",
    "pre-flow-hotfix-finish",
    "pre-flow-hotfix-publish",
    "pre-flow-feature-pull",
    "pre-flow-hotfix-start",
    "pre-flow-hotfix-track",

    "pre-flow-release-branch",
    "pre-flow-release-delete",
    "pre-flow-release-finish",
    "pre-flow-release-publish",
    "pre-flow-release-start",
    "pre-flow-release-track"
};

foreach (var hook in hooks) {
    var hookScript =
    $@"#!/bin/sh
    if [ -f ./.hooks/{hook}.csx ];
    then
        exec ""dotnet"" ""dotnet-script"" ""./.hooks/{hook}.csx"" ""$@""
    else
        exit 0
    fi
    ";
    File.WriteAllText(@$".\.git\hooks\{hook}", hookScript);
}

Logger.LogSuccess("DONE");