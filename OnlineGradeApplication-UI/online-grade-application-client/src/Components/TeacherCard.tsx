import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { Spin, Table } from 'antd';

interface TeacherCardData {
    beganWorkDate: string;
    cafedraId: number;
    positionId: number;
    email: string;
    phoneNumber: string;
    cafedra: string;
    position: string;
}

interface CafedraData {
    cafedraId: number;
    cafedraName: string;
}

interface TeacherPositionData {
    id: number;
    positionName: string;
}

const TeacherCard: React.FC<{ userId: string | undefined }> = ({ userId }) => {
    const [teacherCardData, setTeacherCardData] = useState<TeacherCardData | null>(null);
    const [cafedraData, setCafedraData] = useState<CafedraData | null>(null);
    const [positionData, setPositionData] = useState<TeacherPositionData | null>(null);

    useEffect(() => {
        const fetchTeacherCardData = async () => {
            try {
                const response = await axios.get(`https://localhost:7264/api/TeacherCard/GetTeacherCardByTeacherId?id=${userId}`);
                const [teacherCard] = response.data.$values;
                setTeacherCardData(teacherCard);

                if (teacherCard.cafedraId) {
                    const cafedraResponse = await axios.get(`https://localhost:7264/api/Cafedra/${teacherCard.cafedraId}`);
                    setCafedraData(cafedraResponse.data);
                }

                if (teacherCard.positionId) {
                    const positionResponse = await axios.get(`https://localhost:7264/api/TeacherPosition/${teacherCard.positionId}`);
                    setPositionData(positionResponse.data);
                }
            } catch (error) {
                console.error('Error fetching teacher card data:', error);
            }
        };

        fetchTeacherCardData();
    }, [userId]);

    if (!teacherCardData || !cafedraData || !positionData) {
        return <Spin />;
    }

    const dataSource = [
        {
            key: '1',
            label: 'Email:',
            value: teacherCardData.email,
        },
        {
            key: '2',
            label: 'Телефон:',
            value: teacherCardData.phoneNumber,
        },
        {
            key: '3',
            label: 'Дата початку роботи:',
            value: teacherCardData.beganWorkDate,
        },
        {
            key: '4',
            label: 'Кафедра:',
            value: cafedraData.cafedraName,
        },
        {
            key: '5',
            label: 'Позиція:',
            value: positionData.positionName,
        },
    ];

    const columns = [
        {
            title: 'Стовбець',
            dataIndex: 'label',
            key: 'label',
        },
        {
            title: 'Значення',
            dataIndex: 'value',
            key: 'value',
        },
    ];

    return (
        <div style={{ width: '100%' }}>
            <h2>Карта викладача:</h2>
            <Table dataSource={dataSource} columns={columns} pagination={false} />
        </div>
    );
};

export default TeacherCard;
