
class Student(object):
    def __init__(self, name = None, grade_class= None, phone= None, avg_grade= None):
        self.name = name
        self.grade_class = grade_class
        self.phone = phone
        self.avg_grade = avg_grade
        self.next = None


class StudentArray(object):
    def __init__(self):
        self.before = None

    def insertStudent(self, student):
        if self.before == None:
            self.before = student
        else:
            temp = self.before
            self.before = student
            student.next = temp

    def searchStudent(self, name=None, grade_class=None, phone=None, avg_grade=None):
        filteredStudent = self
        if name != None:
            # searchKey += name
            filteredStudent = self.searchByKey(filteredStudent, "name", name)
        if grade_class != None:
            # searchKey += str(class)
            filteredStudent = self.searchByKey(filteredStudent, "grade_class", grade_class)
        if phone != None:
            # searchKey += str(phone)
            filteredStudent = self.searchByKey(filteredStudent, "phone", phone)
        if avg_grade != None:
            # searchKey += str(avg_grade)
            filteredStudent = self.searchByKey(
                filteredStudent, "avg_grade", avg_grade)

        return filteredStudent

    def searchByKey(self, studentArray, key, value):
        temp = studentArray.before
        filterStudent = StudentArray()
        while temp.next != None:
            if key == "name":
                if temp.name == value:
                    filterStudent.insertStudent(temp)
            elif key == "grade_class":
                if(temp.grade_class == value):
                    filterStudent.insertStudent(temp)
            elif key == "phone":
                if(temp.phone == value):
                    filterStudent.insertStudent(temp)
            elif key == "avg_grade":
                if(temp.avg_grade == value):
                    filterStudent.insertStudent(temp)
            temp = temp.next
        return filterStudent


if __name__ == "__main__":
    f = open("StudentList.txt", "r")

    listStudents = StudentArray()

    content = f.readlines()
    for i in content:
        data = i.split(",")
        aStudent = Student(data[0], data[1], data[2], data[3])
        listStudents.insertStudent(aStudent)
    
    print(listStudents)
        

    


