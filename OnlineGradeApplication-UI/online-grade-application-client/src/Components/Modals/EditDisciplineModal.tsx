import React, { useState, useEffect } from 'react';
import { Modal, Button, Select } from 'antd';
import axios from 'axios';

const { Option } = Select;

interface DisciplineModalProps {
    visible: boolean;
    onSave: () => void;
    onCancel: () => void;
    onUpdate: () => void;
    isEditMode: boolean;
    record?: {
        id: string;
        student: any;
        teacher: any;
        group: any;
        discipline: any;
        teacherGroupDbId: number;
    };
}

interface Group {
    groupId: string;
    groupName: string;
}

interface Teacher {
    id: string;
    firstName: string;
    lastName: string;
}

interface Discipline {
    id: string;
    disciplineName: string;
}

const EditDisciplineModal: React.FC<DisciplineModalProps> = ({ visible, onSave, onCancel, record , onUpdate, isEditMode}) => {
    const [groups, setGroups] = useState<Group[]>([]);
    const [teachers, setTeachers] = useState<Teacher[]>([]);
    const [disciplines, setDisciplines] = useState<Discipline[]>([]);

    const [selectedGroup, setSelectedGroup] = useState<string | null>(record?.group.groupId);
    const [selectedTeacher, setSelectedTeacher] = useState<string | null>(record?.teacher.id);
    const [selectedDiscipline, setSelectedDiscipline] = useState<string | null>(record?.discipline.id);

    useEffect(() => {
        if (record) {
            setSelectedGroup(record.group.groupId);
            setSelectedTeacher(record.teacher.id);
            setSelectedDiscipline(record.discipline.id);
        }
    }, [record]);

    const fetchGroups = async () => {
        const response = await axios.get("https://localhost:7264/api/Group");
        const data = response.data;

        if (data && data.$values) {
            return data.$values;
        }
        return [];
    };

    const fetchTeachers = async () => {
        const response = await axios.get("https://localhost:7264/api/Person/GetTeachers");
        const data = response.data;
        if (data && data.$values) {
            return data.$values;
        }
        return [];
    };

    const fetchDisciplines = async () => {
        const response = await axios.get("https://localhost:7264/api/Discipline");
        const data = response.data;
        if (data && data.$values) {
            return data.$values;
        }
        return [];
    };

    useEffect(() => {
        const fetchData = async () => {
            const [groupsData, teachersData, disciplinesData] = await Promise.all([
                fetchGroups(),
                fetchTeachers(),
                fetchDisciplines()
            ]);
            setGroups(groupsData);
            setTeachers(teachersData);
            setDisciplines(disciplinesData);
        };

        fetchData();
    }, []);

    const handleSubmit = async () => {
        try {
            console.log(record);
            console.log(selectedGroup);
            console.log(selectedTeacher);
            console.log(selectedDiscipline);
            if (selectedGroup && selectedTeacher && selectedDiscipline) {
                let response;
                if(isEditMode && record) {
                    response = await axios.post(
                        `https://localhost:7264/EditDisciplineInSchedule?id=${record.teacherGroupDbId}&teacherId=${selectedTeacher}&groupId=${selectedGroup}&disciplineId=${selectedDiscipline}`
                    );
                } else {
                    response = await axios.post(
                        'https://localhost:7264/api/TeacherGroup',
                        {
                            groupId: selectedGroup,
                            disciplineId: selectedDiscipline,
                            teacherId: selectedTeacher,
                            teacherGroupDisciplineYear: 0 // You can set it to the current year or to 0
                        }
                    );
                }
                // Handle the response if necessary
                console.log(response);
                // Call the onSave prop to update the parent component
                onSave();
                onUpdate();
            } else {
                // Show an error message if any field is not selected
                console.error('All fields must be selected');
            }
        } catch (error) {
            console.error('Error updating the discipline:', error);
        }
    };


    let groupOptions = null;
    if (Array.isArray(groups)) {
        groupOptions = groups.map((group) => (
            <Option key={group.groupId} value={group.groupId}>
                {`${group.groupName}`}
            </Option>
        ));
    }

    let teacherOptions = null;
    if (Array.isArray(teachers)) {
        teacherOptions = teachers.map((teacher) => (
            <Option key={teacher.id} value={teacher.id}>
                {`${teacher.firstName} ${teacher.lastName}`}
            </Option>
        ));
    }

    let disciplineOptions = null;
    if (Array.isArray(disciplines)) {
        disciplineOptions = disciplines.map((discipline) => (
            <Option key={discipline.id} value={discipline.id}>
                {discipline.disciplineName}
            </Option>
        ));
    }

    return (
        <Modal
            title={isEditMode ? "Дисципліна. Редагування" : "Дисципліна. Додавання"}
            visible={visible}
            onOk={handleSubmit}
            onCancel={onCancel}
        >
            <>
                <Select
                    value={selectedGroup}
                    placeholder="Група"
                    style={{ width: '100%', marginBottom: '16px' }}
                    onChange={(value: string) => setSelectedGroup(value)}
                >
                    {groupOptions}
                </Select>

                <Select
                    value={selectedTeacher}
                    placeholder="Викладач"
                    style={{ width: '100%', marginBottom: '16px' }}
                    onChange={(value: string) => setSelectedTeacher(value)}
                >
                    {teacherOptions}
                </Select>

                <Select
                    value={selectedDiscipline}
                    placeholder="Дисципліна"
                    style={{ width: '100%' }}
                    onChange={(value: string) => setSelectedDiscipline(value)}
                >
                    {disciplineOptions}
                </Select>
            </>
        </Modal>
    );
};

export default EditDisciplineModal;
