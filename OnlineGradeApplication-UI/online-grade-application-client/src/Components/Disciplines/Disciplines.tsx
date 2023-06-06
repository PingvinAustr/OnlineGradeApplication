import React, { useEffect, useState } from 'react';
import {Button, Table} from 'antd';
import {deleteGroupTeacherDisciplineEntry, getDisciplinesOfCurrentUser} from '../../Requests/Requests';
import { useAuth } from '../../Auth/AuthContext';
import './Disciplines.styles.css';
import InfoPopup from"../Popups/InfoPopup";
import EditDisciplineModal from "../Modals/EditDisciplineModal";
import Cookies from "js-cookie";


const Disciplines: React.FC = () => {
    const { userId, userRoleId} = useAuth();
    const [disciplines, setDisciplines] = useState<Array<{ id: string, student: any, teacher: any, group: any, discipline: any, teacherGroupDbId:number }>>([]);
    const [selectedRowKeys, setSelectedRowKeys] = useState<React.Key[]>([]);
    const [editingRecord, setEditingRecord] = useState<{ id: string, student: any, teacher: any, group: any, discipline: any, teacherGroupDbId: number } | undefined
        >(undefined);
    const [showPopup, setShowPopup] = useState<boolean>(false);
    const [editModalVisible, setEditModalVisible] = useState(false);
    const [addingRecord, setAddingRecord] = useState(false);
    const [addModalVisible, setAddModalVisible] = useState(false); // New state for Add Modal

    const onSelectChange = (selectedKeys: React.Key[]) => {
        setSelectedRowKeys(selectedKeys);
    };

    const onAddButtonClick = () => {
        setAddingRecord(true);
        setAddModalVisible(true);
    };

    const rowSelection = {
        selectedRowKeys,
        onChange: onSelectChange,
    };

    const renderButtons = () => {
        if (userRoleId === 1 || userRoleId === 2) {
            return (
                <>
                    <Button type="primary" style={{ marginRight: '10px' }} onClick={onAddButtonClick}>Додати</Button>
                    <Button type="primary" style={{ marginRight: '10px' }} danger onClick={onDeleteButtonClick}>Видалити</Button>
                    <Button type="primary" onClick={onEditButtonClick}>Редагувати</Button>
                </>
            );
        }
        return null;
    };

    const fetchDisciplines = async () => {
        try {
            const response = await getDisciplinesOfCurrentUser(userId);
            console.log("_");
            console.log(response.$values);
            setDisciplines(response.$values);
        } catch (error) {
            console.error("Error fetching disciplines:", error);
        }
    };

    useEffect(() => {

        if (userId) {
            Cookies.set("lastTab", "Disciplines");
            fetchDisciplines();
        }
    }, [userId]);

    useEffect(() => {
        if (editingRecord) {
            console.log('Editing record:', editingRecord);
        }
    }, [editingRecord]);

    const onDeleteButtonClick = async () => {
        if (selectedRowKeys.length > 0) {
            try {
                await Promise.all(selectedRowKeys.map(key => deleteGroupTeacherDisciplineEntry(parseInt(key.toString()))));
                setSelectedRowKeys([]);
                fetchDisciplines();
            } catch (error) {
                console.error('Error deleting entries:', error);
            }
        }
    };

    const onEditButtonClick = () => {
        if (selectedRowKeys.length === 1) {
            const record = disciplines.find(d => d.teacherGroupDbId === parseInt(selectedRowKeys[0].toString()));
            console.log(record);
            setEditingRecord(record);
            setEditModalVisible(true);
        } else {
            setShowPopup(true);
        }
    };

    const columns = [
        {
            title: 'Дисципліна',
            dataIndex: 'discipline',
            key: 'disciplineName',
            render: (discipline: any) => discipline.disciplineName,
        },
        {
            title: 'Викладач',
            dataIndex: 'teacher',
            key: 'teacherName',
            render: (teacher: any) => `${teacher.firstName} ${teacher.lastName}`,
        },
        {
            title: 'Група',
            dataIndex: 'group',
            key: 'groupName',
            render: (group: any) => group.groupName,
        },
    ];

    return (
        <div>
            <div className="disciplineHeading">
                <h2>Дисципліни</h2>
                <div className="crudButtonsContainer">{renderButtons()}</div>
            </div>
            <Table dataSource={disciplines} columns={columns} rowKey={(record) => `${record.teacherGroupDbId}`} rowSelection={userRoleId === 1 || userRoleId === 2 ? rowSelection : undefined} />
            {showPopup && <InfoPopup content="Будь ласка оберіть лише 1 запис. Ви не можете редагувати декілька записів одночасно" />}
            <EditDisciplineModal
                record={undefined}
                visible={addModalVisible}
                onSave={() => {
                    setAddModalVisible(false);
                    fetchDisciplines();
                }}
                onCancel={() => {
                    setAddModalVisible(false);
                }}
                isEditMode={false}
                onUpdate={fetchDisciplines}
            />
            <EditDisciplineModal
                record={editingRecord}
                visible={editModalVisible}
                onSave={() => {
                    setEditModalVisible(false);
                    fetchDisciplines();
                }}
                onCancel={() => {
                    setEditModalVisible(false);
                }}
                isEditMode={true}
                onUpdate={fetchDisciplines}
            />
        </div>
    );
};

export default Disciplines;
