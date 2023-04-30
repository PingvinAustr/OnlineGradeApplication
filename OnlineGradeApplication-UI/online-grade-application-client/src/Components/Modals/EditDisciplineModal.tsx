import React, { useState, useEffect } from 'react';
import { Modal, Button, Select } from 'antd';
import axios from 'axios';

const { Option } = Select;

interface EditDisciplineModalProps {
    visible: boolean;
    onSave: () => void;
    onCancel: () => void;
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

const EditDisciplineModal: React.FC<EditDisciplineModalProps> = ({ visible, onSave, onCancel }) => {
    const [groups, setGroups] = useState<Group[]>([]);
    const [teachers, setTeachers] = useState<Teacher[]>([]);
    const [disciplines, setDisciplines] = useState<Discipline[]>([]);

    const fetchGroups = async () => {
        const response = await axios.get("https://localhost:7264/api/Group");
        const data = response.data;
        console.log(data.$values);
        console.log(data.$values);
        console.log(data.$values);
        console.log(data.$values);
        console.log(data.$values);
        console.log(data.$values);

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
            title="Дисципліна. Редагування"
            visible={visible}
            onOk={onSave}
            onCancel={onCancel}
        >
            <>
                <Select
                    placeholder="Група"
                    style={{ width: '100%', marginBottom: '16px' }}
                >
                    {groupOptions}
                </Select>

                <Select
                    placeholder="Викладач"
                    style={{ width: '100%', marginBottom: '16px' }}
                >
                    {teacherOptions}
                </Select>

                <Select
                    placeholder="Дисципліна"
                    style={{ width: '100%' }}
                >
                    {disciplineOptions}
                </Select>
            </>
        </Modal>
    );
};

export default EditDisciplineModal;
