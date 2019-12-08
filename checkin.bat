@echo off
git status

echo Press enter to check-in. CTRL+C/Z to exit
pause
git add .

git commit -m "1"

git push origin master
