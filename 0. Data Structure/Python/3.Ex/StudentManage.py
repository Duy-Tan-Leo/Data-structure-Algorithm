from os import name, path
import os
import os.path
from datetime import date


class Student(object):
    def __init__(self, name=None, grade_class=None, phone=None, avg_grade=None):
        self.data = {
            "name": name,
            "grade_class": grade_class,
            "phone": phone,
            "avg_grade": avg_grade
        }
        self.next = None

    
    def printStudent(self):
        data = "|"
        for key in self.data:
            data += self.data[key] +  " | "
        if data != "|":
            print(data)

class StudentArray(object):
    def __init__(self):
        self.before = None
        self.len = 0
        self.grade_point = []

    def len_increase(self):
        self.len += 1

    def insertStudent(self, student):
        if self.before == None:
            self.before = student
        else:
            temp = self.before
            self.before = student
            student.next = temp

    def checkMatchingValue(self, datasource, compareddata):
        for key in datasource:
            if(datasource[key] != ""):
                if(compareddata[key] != datasource[key]):
                    return False
        return True

    def searchByKey(self, compareddata):
        temp = self.before
        filterStudent = []
        while temp:
            if(self.checkMatchingValue(compareddata, temp.data)):
                filterStudent.append(temp)
            temp = temp.next
        return filterStudent
        # grade_classphone,avg_grade

    def user_input_student(self):
        print("Please enter these folowing information")
        print("If there are some information is empty, please leave it empty and press enter")
        name = input("Student's name: ")
        grade_class = input("Student's class: ")
        phone = input("Student's phone: ")
        avg_grade = input("Student's avg_grade: ")

        newStudent = Student(name, grade_class, phone, avg_grade)
        try:
            self.insertStudent(newStudent)
            print("Successfully adding")
        except:
            print("Error in adding a new student")
        
    def input_student_from_file(self):
        pathFile = input("Please enter the file path: ")

        if not path.exists(pathFile):
            print("Uppp! your current file doesn't exist")
        else:
            newFolderPath = path.join(path.abspath(
                os.getcwd()), "List of students")
            if not path.exists(newFolderPath):
                os.mkdir(newFolderPath)
            newPathFile = path.join(newFolderPath, str(
                date.today())+"_ListStudent.txt")
            os.rename(pathFile, newPathFile)

            f = open(newPathFile, "r")
            content = f.readlines()
            for i in range(1,len(content)):
                data = content[i].replace(" ", "").replace("\n","").split(",")
                aStudent = Student(data[0], data[1], data[2], data[3])
                self.insertStudent(aStudent)

    def print_list(self):
        temp = self.before

        # header name, length
        header = {
            "Name": 20,
            "Grade_class": 10,
            "Phone": 15,
            "Avg_grade": 10
        }
        print("___________________________________")
        print("----------List of student----------")
        print(Helper.createHeader(header))

        while temp:
            name = temp.data["name"] + " "*(20 - len(temp.data["name"])) + "|"
            grade_class = temp.data["grade_class"] + " " * \
                (10 - len(temp.data["grade_class"])) + "|"
            phone = temp.data["phone"] + " " * \
                (15 - len(temp.data["phone"])) + "|"
            avg_grade = temp.data["avg_grade"] + " " * \
                (10 - len(str(temp.data["avg_grade"]))) + "|"

            print(name, grade_class, phone, avg_grade)
            temp = temp.next
        print("___________________________________")

    def delete_students_by_citeria(self, deletedDict):
        current = self.before
        prvSt = current
        while current:
            if self.checkMatchingValue(deletedDict, current.data):
                if self.checkMatchingValue(deletedDict, self.before.data):
                    self.before = current.next
                else:
                    prvSt.next = current.next
            prvSt = current
            current = current.next

    def sorting(self):
        temp = self.before.next
        prv = self.before
        while temp:
            prv.next = temp.next
            sorted = self.sort(temp)
            if not sorted:
                prv.next = temp
            prv = temp
            temp = temp.next

    def sort(self, currentValue):
        temp = self.before
        prv = temp
        if float(self.before.data["avg_grade"]) <= float(currentValue.data["avg_grade"]):
            self.insertStudent(currentValue)
            return True
        else:
            while temp:
                if float(temp.data["avg_grade"]) < float(currentValue.data["avg_grade"]):
                    prv.next = currentValue
                    currentValue.next = temp
                    return True
                prv = temp
                temp = temp.next
            return False

class Helper:
    def createHeader(array):
        header = "| "
        for key in array:
            keyLen = int((array[key] - len(key))/2 - 1)
            hd_space = " " * keyLen
            if(keyLen < 0):
                header += key + " | "
            else:
                header += hd_space + key + hd_space + " |"
        return header

    def getStudentInput():
        name = input("Name of student: ")
        grade_class = input("Grade class of student: ")
        phone = input("Phone of student: ")
        avg_grade = input("Avg grade of student: ")
        return {"name" : name, "grade_class": grade_class, "phone" : phone, "avg_grade" : avg_grade}

if __name__ == "__main__":
    print("Welcome to student management program")
    isContinueProgram = True

    studentArr = StudentArray()

    programMenus = {
        1: "1. Add a new list student manually",
        2: "2. Add new student by a file",
        3: "3. Print out all student from list",
        4: "4. Find a student by name and by phone",
        5: "5. Add a new student manually & print new list",
        6: "6. Delete an class",
        7: "7. Sorting decendingly",
        0: "0. Stop program"
    }

    while isContinueProgram:
        for key in programMenus:
            print(programMenus[key])
        print("\r")

        choice = int(input("Enter your choice: "))

        if choice == 0:
            isContinueProgram = False
            print("End program")
        elif choice == 1:
            studentArr.user_input_student()
        elif choice == 2:
            studentArr.input_student_from_file()
        elif choice == 3:
            # D:\Learning Coding\DSA\App\DSA\0. Data Structure\Python\3.Ex\List of students\2021-06-23_ListStudent.txt
            studentArr.print_list()
        elif choice == 4:
            name = input("Name of student: ")
            grade_class = input("Grade class of student: ")
            phone = input("Phone of student: ")
            avg_grade = input("Avg grade of student: ")

            comparedata = {
                "name": name,
                "grade_class": grade_class,
                "phone": phone,
                "avg_grade": avg_grade
            }

            listStudent = studentArr.searchByKey(comparedata)
            for student in listStudent:
                student.printStudent()
        elif choice == 5:
            studentArr.user_input_student()
            studentArr.print_list()
        elif choice == 6:
            print("Input following information to delete: ")
            deletedKeys = Helper.getStudentInput()
            studentArr.delete_students_by_citeria(deletedKeys)
            studentArr.print_list()
        elif choice == 7:
            print("Sorting: ")
            studentArr.sorting()
            studentArr.print_list()


